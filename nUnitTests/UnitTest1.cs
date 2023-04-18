using Station.DB;

namespace nUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DistanceTest()
        {
            RailConnectionPoint point=new RailConnectionPoint() { X=0, Y=0 };
            RailConnectionPoint next = new RailConnectionPoint() { X = 0, Y = 100 };


           double distace= point.DistanceTo(next);
            if(distace==100)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
             
        }
        [Test]
        public void TestSortPointsInFigure()
        {

        }
    }
}