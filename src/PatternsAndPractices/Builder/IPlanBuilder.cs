namespace PatternsAndPractices.Builder
{
    public interface IPlanBuilder
    {
        void BuildDiskSpaceFeature();
        void BuildDatabaseFeature();
        void BuildBandwidthFeature();
        void BuildSslFeature();

        Plan GetPlan();
    }
}
