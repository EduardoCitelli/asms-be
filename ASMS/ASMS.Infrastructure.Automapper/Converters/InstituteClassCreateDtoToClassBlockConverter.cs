using ASMS.CrossCutting.Extensions;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClasses;
using AutoMapper;

namespace ASMS.Infrastructure.Automapper.Converters
{
    public class InstituteClassCreateDtoToClassBlockConverter : ITypeConverter<InstituteClassCreateDto, ICollection<InstituteClassBlock>>
    {
        public ICollection<InstituteClassBlock> Convert(InstituteClassCreateDto source, ICollection<InstituteClassBlock> destination, ResolutionContext context)
        {
            if (source == null)
                return new List<InstituteClassBlock>();

            if (!source.IsRecurrence)
            {
                var block = context.Mapper.Map<InstituteClassBlock>(source);
                block.DayOfWeek = source.NotRecurrenceDate!.Value.DayOfWeek;

                return new List<InstituteClassBlock>() { block };
            }

            var dates = DateTimeExtensions.GetDaysInRange(source.FromRange!.Value, source.ToRange!.Value, source.DaysOfWeek!);

            return dates.Select(date =>
            {
                var block = context.Mapper.Map<InstituteClassBlock>(source);

                block.DayOfWeek = date.SetTime(source.StartTime).DayOfWeek;

                block.StartDateTime = date.SetTime(source.StartTime)
                                          .AddOffset(source.ClientOffset);

                block.FinishDateTime = block.StartDateTime
                                            .AddMinutes(source.MinutesDuration);

                return block;
            }).ToList();
        }
    }
}
