using System.Security.Policy;
using BE.Dto.Follow;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

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
                .Select(f => f.FollowedId)
                .ToListAsync();

            var users = await _context.Users
                .Where(u => listFollow.Contains(u.Id))
                .ToListAsync();

            var resultList = new List<FollowingDto>();


            foreach (var v in listFollow)
            {
                var user = await _context.Users.FirstOrDefaultAsync(us => us.Id == v);

                var countFollower = await _context.Follows
                    .Where(f => f.FollowedId == user.Id)
                    .CountAsync();


                var countCourses = await _context.Courses
                    .Where(f => f.UserId == user.Id)
                    .CountAsync();

                List<Image> images = await _context.Images
                    .Where(image => image.UserId == user.Id)
                    .ToListAsync();

                var ListUrls = images.Select(i => i.Url).ToList();

                var following = new FollowingDto
                {
                    FolloweId = v,
                    UserId = user.Id,
                    Name = user.Username,
                    ListImage = ListUrls,
                    Follower = countFollower,
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
