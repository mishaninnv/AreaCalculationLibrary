using AreaCalculationLibrary;

namespace AreaCalculationLibraryTests
{
    public class Tests
    {
        private Area _area;
        private Random _random;

        [SetUp]
        public void Setup()
        {
            _area = new Area();
            _random = new Random();
        }

        [Test]
        public void CircleAreaTest()
        {
            // Arrange
            var counter = 30;
            var results = new Dictionary<double, double>();

            // Act
            for (var i = 0; i < counter; i++)
            {
                var radius = _random.Next(10) * _random.NextDouble();

                var expectResult = Math.Round(Math.PI * Math.Pow(radius, 2), 3);
                var result = _area.Calculate(radius);

                results.TryAdd(expectResult, result);
            }

            //Assert
            foreach (var example in results)
            {
                Assert.That(example.Value, Is.EqualTo(example.Key));   
            }
        }

        [Test]
        public void TriangleAreaTest()
        {
            // Arrange
            var counter = 30;
            var results = new Dictionary<double, double>();

            // Act
            for (var i = 0; i < counter; i++)
            {
                var side1 = _random.Next(10) * _random.NextDouble();
                var side2 = _random.Next(10) * _random.NextDouble();
                var side3 = _random.Next(10) * _random.NextDouble();

                var p = (side1 + side2 + side3) / 2;
                var expectResult = Math.Round(Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3)), 3);
                var result = _area.Calculate(side1, side2, side3);

                results.TryAdd(expectResult, result);
            }

            //Assert
            foreach (var example in results)
            {
                Assert.That(example.Value, Is.EqualTo(example.Key));
            }
        }

        [Test]
        public void ArgumentExceptionTest()
        {
            // Arrange
            var radius = _random.NextDouble() * -1;
            var side1 = _random.NextDouble();
            var side2 = _random.NextDouble() * -1;
            var side3 = _random.NextDouble();

            // Assert
            Assert.Throws<ArgumentException>(() => _area.Calculate(radius));
            Assert.Throws<ArgumentException>(() => _area.Calculate(side1, side2, side3));
        }

        [Test]
        public void ArgumentOutOfRangeExceptionTest()
        {
            // Arrange
            var value1 = _random.NextDouble() * 15;
            var value2 = _random.NextDouble() * 15;
            var value3 = _random.NextDouble() * 15;
            var value4 = _random.NextDouble() * 15;
            var value5 = _random.NextDouble() * 15;

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _area.Calculate(value1, value2, value3, value4, value5));
            Assert.Throws<ArgumentOutOfRangeException>(() => _area.Calculate(value1, value2, value3, value4));
        }
    }
}