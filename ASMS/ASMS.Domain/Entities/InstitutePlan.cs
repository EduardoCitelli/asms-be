using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class InstitutePlan : AuditEntity<long>
    {
        public int PlanId { get; set; }

        public long InstituteId { get; set; }

        public bool IsCurrentPlan { get; set; } = true;

        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public DateOnly? FinishDate { get; set; }

        public virtual Plan Plan { get; set; }

        public virtual Institute Institute { get; set; }
    }
}