﻿using ThesisManagement.BLL.Interfaces;
using ThesisManagement.DAL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Services
{
    public class DefenseScoreService(IUnitOfWork unitOfWork) : IDefenseScoreService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task AddSync(Defense defense)
        {
            _unitOfWork.Defenses.Add(defense);
            await _unitOfWork.Complete();
        }

        public async Task<(bool, Defense)> CheckHaveDefense(Guid idRegitation)
        {
            var defense = await _unitOfWork.Defenses.Find(x => x.RegistrationID.Equals(idRegitation), nameof(Defense.DefenseScores));
            if (defense == null) 
                return (false,new());
            return (true, defense.First());
        }

        public async Task<Defense> GetScore(Guid registationId)
        {
            var defense = await _unitOfWork.Defenses.Find(x => x.RegistrationID.Equals(registationId), nameof(Defense.DefenseScores));
            if (defense.Any()) 
                return defense.First();
            return null;
        }

        public async Task Update(Defense defense)
        {
            _unitOfWork.Defenses.Update(defense);
            await _unitOfWork.Complete();
        }
    }
}
