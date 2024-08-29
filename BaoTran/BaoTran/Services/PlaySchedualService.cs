using AutoMapper;
using BaoTran.Data;
using BaoTran.Models;
using BaoTran.Repository;
using BaoTran.Validators;

namespace BaoTran.Services
{
    public interface IPlaySchedualService
    {
        Task<IEnumerable<PlaySchedualResponse>> GetAllPlaySchedual();
        Task<(bool Success, string ErrorMessage)> PostPlaySchedual(PlaySchedualRequest playSchedualNew);
        Task<(bool Success, string ErrorMessage)> PutPlaySchedual(int id, PlaySchedualRequest playSchedualUpdate);
        Task<(bool Success, string ErrorMessage)> DeletePlaySchedual(int id);

    }

    public class PlaySchedualService : IPlaySchedualService
    {
        private readonly IMapper mapper;
        private readonly PlaySchedualValidator playSchedualValidator;
        private readonly IRepositoryWrapper repository;

        public PlaySchedualService(IMapper mapper, PlaySchedualValidator playSchedualValidator, IRepositoryWrapper repository)
        {
            this.mapper = mapper;
            this.playSchedualValidator = playSchedualValidator;
            this.repository = repository;
        }

        public async Task<IEnumerable<PlaySchedualResponse>> GetAllPlaySchedual()
        {
            IEnumerable<PlaySchedual> playScheduals = await repository.PlayScheduals.GetAllAsync();
            return mapper.Map<IEnumerable<PlaySchedualResponse>>(playScheduals);
        }

        //Thêm 1 lịch phát mới
        public async Task<(bool Success, string ErrorMessage)> PostPlaySchedual(PlaySchedualRequest playSchedualNew)
        {

            (bool isConflict, string errorMessage) result = await playSchedualValidator.IsTimeValid(playSchedualNew);
            if (!result.isConflict)
            {
                return (false, result.errorMessage);
            }

            FluentValidation.Results.ValidationResult validationResult = await playSchedualValidator.ValidateAsync(playSchedualNew);
            if (!validationResult.IsValid)
                return (false, validationResult.Errors.First().ErrorMessage);

            PlaySchedual playSchedual = mapper.Map<PlaySchedual>(playSchedualNew);

            repository.PlayScheduals.Create(playSchedual);
            await repository.SaveChangeAsync();

            return (true, null);

        }



        public async Task<(bool Success, string ErrorMessage)> PutPlaySchedual(int id, PlaySchedualRequest playSchedualUpdate)
        {
            PlaySchedual existingPlaySchedual = await repository.PlayScheduals.GetSingleAsync(g => g.IdPlaySchedual == id);
            if (existingPlaySchedual == null)
                return (false, "Play Schedual not found.");

            FluentValidation.Results.ValidationResult validationResult = await playSchedualValidator.ValidateAsync(playSchedualUpdate);
            if (!validationResult.IsValid)
                return (false, validationResult.Errors.First().ErrorMessage);

            mapper.Map(playSchedualUpdate, existingPlaySchedual);

            repository.PlayScheduals.Update(existingPlaySchedual);
            await repository.SaveChangeAsync();

            return (true, null);
        }



        public async Task<(bool Success, string ErrorMessage)> DeletePlaySchedual(int id)
        {
            PlaySchedual? playSchedual = await repository.PlayScheduals.FirstOrDefaultAsync(u => u.IdPlaySchedual == id);
            if (playSchedual == null)
                return (false, "Play Schedual not found.");

            repository.PlayScheduals.Delete(playSchedual);
            await repository.SaveChangeAsync();

            return (true, null);
        }


    }
}
