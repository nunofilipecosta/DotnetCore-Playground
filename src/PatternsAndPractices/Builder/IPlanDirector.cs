namespace PatternsAndPractices.Builder
{
    public interface IPlanDirector
    {
        void SetPlanBuilder(IPlanBuilder builder);

        void BuildBasicPlan();

        void BuildEnterprisePlan();
    }

    public class PlanDirector : IPlanDirector
    {
        private IPlanBuilder _planBuilder;

        public void SetPlanBuilder(IPlanBuilder builder)
        {
            _planBuilder = builder;
        }

        public void BuildBasicPlan()
        {
            _planBuilder.BuildDiskSpaceFeature();
            _planBuilder.BuildDatabaseFeature();
            _planBuilder.BuildBandwidthFeature();
        }

        public void BuildEnterprisePlan()
        {
            _planBuilder.BuildDiskSpaceFeature();
            _planBuilder.BuildDatabaseFeature();
            _planBuilder.BuildBandwidthFeature();
            _planBuilder.BuildSslFeature();
        }
    }
}