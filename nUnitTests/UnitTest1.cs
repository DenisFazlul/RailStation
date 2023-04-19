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
        public void TestSshortPath() 
        {
            Station.DB.Station station= new Station.DB.Station();
           
            RailConnectionPoint cp1 = station.CreatePoint(0, 0);

            RailConnectionPoint cp2 = station.CreatePoint(100, 0);

            RailConnectionPoint cp3 = station.CreatePoint(0, 100);

            RailConnectionPoint cp4 = station.CreatePoint(100, 1000);

            RailCurve firstCurve = station.CreateCurve(cp1, cp2);

            RailCurve secCurve=station.CreateCurve(cp4,cp3);

            RailCurve leftCurve=station.CreateCurve(cp1,cp3);
            RailCurve rightCurve = station.CreateCurve(cp2, cp4);


            PathSercher serce = new PathSercher();

            serce.SetSerchigFrom(firstCurve, secCurve);

           Task t =Task.Run( serce.RunSerch);
            t.Wait();

           CurvesPath path= serce.GetfastedPath();

            if (path.Curves[0]==leftCurve)
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