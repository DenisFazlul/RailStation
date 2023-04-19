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
            Station.DB.Station station = new Station.DB.Station();

            RailConnectionPoint cp1 = station.CreatePoint(100, 100);

            RailConnectionPoint cp2 = station.CreatePoint(500, 100);

            RailConnectionPoint cp3 = station.CreatePoint(100, 200);

            RailConnectionPoint cp4 = station.CreatePoint(500, 250);

            RailCurve firstCurve = station.CreateCurve(cp1, cp2);

            RailCurve secCurve = station.CreateCurve(cp4, cp3);

            RailCurve leftCurve = station.CreateCurve(cp1, cp3);
            RailCurve rightCurve = station.CreateCurve(cp2, cp4);

            RailPark park = station.CreateRailPark();
            park.AddSegment(firstCurve);
            park.AddSegment(secCurve);
            
            PointsSorter sorter = new PointsSorter();
            sorter.Sort(park.getPoints());

            List<RailConnectionPoint> notSortedPoints = park.getPoints();
            List<RailConnectionPoint> sortedPoints = sorter.GetSortedPoints();
            if (sortedPoints[0]==cp1
                &&
                sortedPoints[1]==cp2
                &&
                sortedPoints[2]==cp4
                &&
                sortedPoints[3]==cp3)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }



        }
    }
}