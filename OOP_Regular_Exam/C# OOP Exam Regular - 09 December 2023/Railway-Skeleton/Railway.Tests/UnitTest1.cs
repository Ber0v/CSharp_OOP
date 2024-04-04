using NUnit.Framework;

namespace Railway.Tests
{
    public class TestRailwayStation
    {
        private RailwayStation station;
        string train = "sofia-varna";

        [SetUp]
        public void SetUp()
        {
            station = new RailwayStation("station");
        }

        [Test]
        public void checkConstructor_Save()
        {
            Assert.AreEqual("station", station.Name);
            Assert.AreEqual(0, station.ArrivalTrains.Count);
            Assert.AreEqual(0, station.DepartureTrains.Count);
        }

        [Test]
        public void TestNewArrivalOnBoard()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var newstation = new RailwayStation(null);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                var newstation = new RailwayStation(" ");
            });
        }

        [Test]
        public void NewArrival()
        {
            station.NewArrivalOnBoard(train);
            Assert.AreEqual(1, station.ArrivalTrains.Count);
            Assert.AreEqual($"{train}", station.ArrivalTrains.Dequeue());
        }

        [Test]
        public void TrainHasArrivaled()
        {
            station.NewArrivalOnBoard($"{train}");

            Assert.AreEqual("There are other trains to arrive before varna-sofia.", station.TrainHasArrived("varna-sofia"));
            Assert.AreEqual($"{train} is on the platform and will leave in 5 minutes.", station.TrainHasArrived($"{train}"));

            Assert.AreEqual(1, station.DepartureTrains.Count);
            Assert.AreEqual($"{train}", station.DepartureTrains.Dequeue());
            Assert.AreEqual(0, station.ArrivalTrains.Count);

        }

        [Test]
        public void TrainHasArrivaled2()
        {
            station.NewArrivalOnBoard(train);

            station.TrainHasArrived(train);

            Assert.AreEqual(false, station.TrainHasLeft("Non existant"));
            Assert.AreEqual(true, station.TrainHasLeft(train));
            Assert.AreEqual(0, station.DepartureTrains.Count);
        }
    }
}
