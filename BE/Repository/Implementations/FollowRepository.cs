using System.Security.Policy;
using BE.Dto.Follow;
using BE.Dto.User;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using BE.Dto.Follow;
using BE.Dto.ImageD;
using BE.Dto.Course;

namespace BE.Repository.Implementations
{
     public class FollowRepository : IFollowRepository
     {
          private readonly CourseOnlContext _context;
          public FollowRepository(CourseOnlContext context)
          {
               _context = context;
          }
          
         public async Task<FollowingDto> GetFollowing(string UserId)
          {
          var followingDto = new FollowingDto();

          var follows = await _context.Follows
               .Include(f => f.Follower)
               .Include(f => f.Followed)
                    .ThenInclude(u => u.Images)
               .Include(f => f.Followed)
                    .ThenInclude(u => u.Courses)
                         .ThenInclude(c => c.Images)
               .Include(f => f.Followed)
                    .ThenInclude(u => u.FollowFolloweds)
               .Include(f => f.Followed)
                    .ThenInclude(u => u.FollowFollowers)
               .Where(f => f.FollowerId == UserId)
               .ToListAsync();

          var followedDict = new Dictionary<string, UserInfoFollowingDto>();

          foreach (var follow in follows)
          {
               var followedUser = follow.Followed;

               if (followedUser != null && !followedDict.ContainsKey(followedUser.Id))
               {
                    var followedIds = await _context.Follows
                         .Where(f => f.FollowerId == followedUser.Id)
                         .Select(f => f.FollowedId)
                         .Distinct()
                         .ToListAsync();

                    var userInfo = MapUserToUserInfoDto(followedUser, followedIds);
                    followedDict[followedUser.Id] = userInfo;
               }
          }

          followingDto.FollowFolloweds = followedDict.Values.ToList();
          followingDto.FollowingListOfUserId = UserId;

          return followingDto;
          }

          private UserInfoFollowingDto MapUserToUserInfoDto(User user, List<string> followedIds)
          {
               var userInfo = new UserInfoFollowingDto
               {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Username,
                    CoursesCount = user.Courses.Count(),
                    FollowerCount = user.FollowFollowers.Count(),
                    FollowedCount = user.FollowFolloweds.Count(),
                    Images = user.Images.Select(i => new ImageForAdminDto
                    {
                         Id = i.Id,
                         Url = i.Url,
                         Type = i.Type,
                         LastUpdated = i.CreatedAt
                    }).ToList(),
                    Courses = user.Courses.Select(c => new CourseInfoFollowingDto
                    {
                         Id = c.Id,
                         Name = c.Name,
                         Rating = c.Rating,
                         Price = c.Price,
                    }).ToList(),
                    FollowFolloweds = user.FollowFolloweds
                                        .Select(ff => new UserInfoFollowingDto
                                        {
                                             Id = ff.Followed.Id,
                                             Email = ff.Followed.Email,
                                             Name = ff.Followed.Username,
                                        }).ToList(),
                    FollowFollowers = _context.Users 
                                        .Where(u => followedIds.Contains(u.Id))
                                        .Select(u => new UserInfoFollowingDto
                                        {
                                             Id = u.Id,
                                             Email = u.Email,
                                             Name = u.Username,
                                             Images = u.Images.Select(i => new ImageForAdminDto
                                             {
                                                  Id = i.Id,
                                                  Url = i.Url,
                                                  Type = i.Type,
                                                  LastUpdated = i.CreatedAt
                                             }).ToList(),
                                             CoursesCount = u.Courses.Count(), 
                                             FollowerCount = u.FollowFollowers.Count(), 
                                             FollowedCount = u.FollowFolloweds.Count(), 
                                             Courses = u.Courses.Select(c => new CourseInfoFollowingDto
                                             {
                                                  Id = c.Id,
                                                  Name = c.Name,
                                                  Rating = c.Rating,
                                                  Price = c.Price,
                                             }).ToList(),
                                             FollowFollowers = u.FollowFollowers 
                                                  .Select(ff => new UserInfoFollowingDto
                                                  {
                                                       Id = ff.Follower.Id,
                                                       Email = ff.Follower.Email,
                                                       Name = ff.Follower.Username,
                                                  }).ToList(),
                                        }).ToList()
               };

               return userInfo;
          }

          //---------------------CRUD--------------------------//
          public async Task<Follow?> CreateFollow(Follow follow)
          {
               await _context.Follows.AddAsync(follow);
               await _context.SaveChangesAsync();
               return follow;
          }

          public async Task<bool> DeleteFollow(string followId)
          {
               var follow = await _context.Follows.FindAsync(followId);

               if (follow == null) return false;

               _context.Follows.Remove(follow);
               await _context.SaveChangesAsync();
               return true;
          }

          public async Task<List<Follow>> GetAllFollows()
          {
               return await _context.Follows.ToListAsync();
          }

          public async Task<Follow?> GetFollowById(string followId)
          {
               return await _context.Follows.FirstOrDefaultAsync(follow => follow.Id == followId);
          }

          public async Task<Follow?> UpdateFollow(Follow follow)
          {
               _context.Follows.Update(follow);
               await _context.SaveChangesAsync();
               return follow;
          }
     }
}
