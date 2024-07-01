using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;
using BE.Utils;

namespace BE.Services.Implementations
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;

        public FollowService(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
        }

        public async Task<IEnumerable<Follow>> GetAllFollowsAsync()
        {
            return await _followRepository.GetAllFollowsAsync();
        }

        public async Task<Follow> GetFollowByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Follow ID cannot be null or empty.");
            }

            var follow = await _followRepository.GetFollowByIdAsync(id);
            if (follow == null)
            {
                throw new Exception("Follow not found.");
            }

            return follow;
        }

        public async Task AddFollowAsync(Follow follow)
        {
            if (follow == null)
            {
                throw new Exception("Follow cannot be null.");
            }
            follow.Id = Utils.Utils.GenerateIdModel("Follow");
            follow.Time = Utils.Utils.GetTimeNow();

            await _followRepository.AddFollowAsync(follow);
        }

        public async Task UpdateFollowAsync(Follow follow)
        {
            if (follow == null)
            {
                throw new Exception("Follow cannot be null.");
            }

            var existingFollow = await _followRepository.GetFollowByIdAsync(follow.Id);
            if (existingFollow == null)
            {
                throw new Exception("Follow not found.");
            }

            await _followRepository.UpdateFollowAsync(follow);
        }

        public async Task DeleteFollowAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Follow ID cannot be null or empty.");
            }

            var follow = await _followRepository.GetFollowByIdAsync(id);
            if (follow == null)
            {
                throw new Exception("Follow not found.");
            }

            await _followRepository.DeleteFollowAsync(id);
        }
    }
}
