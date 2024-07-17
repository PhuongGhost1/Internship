using System.Security.Policy;
using BE.Dto.Follow;
using BE.Dto.User;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using BE.Dto.Follow;

namespace BE.Repository.Implementations
{
     public class FollowRepository : IFollowRepository
     {
          private readonly CourseOnlContext _context;
          public FollowRepository(CourseOnlContext context)
          {
               _context = context;
          }
          public async Task<List<FollowingDto>> GetFollowing(string followUserId)
          {
               var listFollow = await _context.Follows
                   .Where(f => f.FollowerId == followUserId)
                   .ToListAsync();

               var resultList = new List<FollowingDto>();


               foreach (var v in listFollow)
               {
                    var user = await _context.Users.FirstOrDefaultAsync(us => us.Id == v.FollowedId);

                    var followerIds = await _context.Follows
                        .Where(f => f.FollowedId == user.Id)
                        .Select(f => f.FollowerId)
                        .ToListAsync();

                    var followCount = followerIds.Count();

                    var followers = await _context.Users
                        .Where(u => followerIds.Contains(u.Id))
                        .ToListAsync();

                    var listFollower = new List<BasicInfoUser>();

                    foreach (var fl in followers)
                    {
                         List<Image> FollowImage = await _context.Images
                         .Where(image => image.UserId == fl.Id)
                         .ToListAsync();

                         var ListUrl = FollowImage.Select(i => i.Url).ToList();
                         var follower = new BasicInfoUser
                         {
                              Id = fl.Id,
                              Name = fl.Name,
                              ListImage = ListUrl,
                              DOB = fl.Dob,
                              Gender = fl.Gender,
                              Email = fl.Email
                         };
                         listFollower.Add(follower);
                    }

                    var countCourses = await _context.Courses
                        .Where(f => f.UserId == user.Id)
                        .CountAsync();

                    List<Image> images = await _context.Images
                        .Where(image => image.UserId == user.Id)
                        .ToListAsync();


                    var ListUrls = images.Select(i => i.Url).ToList();

                    var following = new FollowingDto
                    {
                         FollowId = v.Id,
                         UserId = user.Id,
                         Name = user.Username,
                         ListImage = ListUrls,
                         ListFollower = listFollower,
                         Follower = followCount,
                         Course = countCourses
                    };
                    resultList.Add(following);
               }


               return resultList;
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
