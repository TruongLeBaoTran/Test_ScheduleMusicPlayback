using BaoTran.Data;
using BaoTran.Models;
using BaoTran.Repository;
using FluentValidation;

namespace BaoTran.Validators
{
    public class PlaySchedualValidator : AbstractValidator<PlaySchedualRequest>
    {
        private readonly IRepositoryWrapper repository;
        public PlaySchedualValidator(IRepositoryWrapper repositoryWrapper)
        {
            repository = repositoryWrapper;

            RuleFor(x => x.DaysOfWeek)
                .NotEmpty().WithMessage("Ngày trong tuần không được để trống.")
                .Must(BeAValidDayOfWeek).WithMessage("Ngày trong tuần không hợp lệ.");

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Thời gian bắt đầu không được để trống.")
                .Must(BeAValidTime).WithMessage("Thời gian bắt đầu không hợp lệ.");


            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("Thời gian kết thúc không được để trống.")
                .Must(BeAValidTime).WithMessage("Thời gian kết thúc không hợp lệ.")
                .GreaterThan(x => x.StartTime).WithMessage("Thời gian kết thúc phải sau thời gian bắt đầu.");


            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Ngày bắt đầu không được để trống.")
                .Must(BeAValidDate).WithMessage("Ngày bắt đầu không hợp lệ.");


            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("Ngày kết thúc không được để trống.")
                .Must(BeAValidDate).WithMessage("Ngày kết thúc không hợp lệ.")
                .GreaterThanOrEqualTo(x => x.StartDate).WithMessage("Ngày kết thúc phải sau hoặc bằng ngày bắt đầu.");


            RuleFor(x => x.IdMediaFile)
                .GreaterThan(0).WithMessage("IdMediaFile phải lớn hơn 0.");
        }

        private bool BeAValidDayOfWeek(string dayOfWeek)
        {
            return Enum.TryParse<DayOfWeek>(dayOfWeek, true, out _);
        }

        private bool BeAValidTime(string time)
        {
            return TimeSpan.TryParse(time, out _);
        }

        private bool BeAValidDate(string date)
        {
            return DateTime.TryParse(date, out _);
        }


        public async Task<(bool, string)> IsTimeValid(PlaySchedualRequest playSchedualNew)
        {
            DateTime startDate = DateTime.Parse(playSchedualNew.StartDate).Date;
            DateTime endDate = DateTime.Parse(playSchedualNew.EndDate).Date;
            TimeSpan startTime = TimeSpan.Parse(playSchedualNew.StartTime);
            TimeSpan endTime = TimeSpan.Parse(playSchedualNew.EndTime);
            DayOfWeek dayOfWeek = Enum.Parse<DayOfWeek>(playSchedualNew.DaysOfWeek);

            List<DateTime> scheduledDates = new(); //những ngày vừa lên lịch
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == dayOfWeek)
                {
                    scheduledDates.Add(date);
                }
            }

            IEnumerable<PlaySchedual> allSchedules = await repository.PlayScheduals.GetAllAsync();
            foreach (PlaySchedual ps in allSchedules)
            {
                List<DateTime> preSheduledDays = new();//những ngày đã lên lịch trước đó trong db
                for (DateTime date = ps.StartDate; date <= ps.EndDate; date = date.AddDays(1))
                {
                    if (date.DayOfWeek == ps.DaysOfWeek)
                    {
                        preSheduledDays.Add(date);
                    }
                }

                bool isDateOverlap = scheduledDates.Any(sd => preSheduledDays.Contains(sd));
                if (isDateOverlap) //Nếu trùng ngày thì kiểm xem giờ có trùng không
                {
                    if (ps.StartTime < endTime && ps.EndTime > startTime)
                    {
                        return (false, "Lịch trình đã tồn tại trong khoảng thời gian này.");
                    }
                }
            }

            return (true, string.Empty);
        }
    }
}