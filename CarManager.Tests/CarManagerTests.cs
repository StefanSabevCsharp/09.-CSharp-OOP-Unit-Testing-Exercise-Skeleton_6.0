namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        //we should test every element of the class
        //starting with the constructor
        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 7.5;
            var fuelCapacity = 50.0;
            //Act
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            //Assert
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }
        [Test]
        public void MakeShouldThrowExceptionWhenMakeIsNull()
        {
            //Arrange
            var make = "";
            var model = "Golf";
            var fuelConsumption = 7.5;
            var fuelCapacity = 50.0;
            //Act
            //Assert
            Assert.That(() => new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }
        [Test]
        public void MakeShouldThrowExceptionWhenMakeIsEmpty()
        {
            //Arrange
            var make = "";
            var model = "Golf";
            var fuelConsumption = 7.5;
            var fuelCapacity = 50.0;
            //Act
            //Assert
            Assert.That(() => new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }
        [Test]
        public void ModelShouldThrowExceptionWhenModelIsNull()
        {
            //Arrange
            var make = "VW";
            var model = "";
            var fuelConsumption = 7.5;
            var fuelCapacity = 50.0;
            //Act
            //Assert
            Assert.That(() => new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }
        [Test]
        public void ModelShouldThrowExceptionWhenModelIsEmpty()
        {
            //Arrange
            var make = "VW";
            var model = "";
            var fuelConsumption = 7.5;
            var fuelCapacity = 50.0;
            //Act
            //Assert
            Assert.That(() => new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }
        [Test]
        public void FuelConsumptionShouldThrowExceptionWhenFuelConsumptionIsNegative()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = -7.5;
            var fuelCapacity = 50.0;

            //Assert
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity), "Fuel consumption cannot be negative!");
        }

        [Test]
        public void FuelConsumptionShouldThrowExceptionWhenFuelConsumptionIsZero()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 0;
            var fuelCapacity = 50.0;
            Car car = null;
            //Act
            try
            {
                car = new Car(make, model, fuelConsumption, fuelCapacity);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Fuel consumption cannot be zero or negative!", ex.Message);
            }

            // Assert
            Assert.IsNull(car, "Car is not null!");
        }
        [Test]
        public void FuelCapacityShouldThrowExceptionWhenFuelCapacityIsNegative()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 7.5;
            var fuelCapacity = -50.0;
            //Act
            //Assert
            Assert.That(() => new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }
        [Test]
        public void FuelCapacityShouldThrowExceptionWhenFuelCapacityIsZero()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 7.5;
            var fuelCapacity = 0;
            //Act
            //Assert
            Assert.That(() => new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }
        [Test]
        public void FuelAmountShouldBeZeroWhenCarIsCreated()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 7.5;
            var fuelCapacity = 50.0;
            //Act
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            //Assert
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        public void RefuelShouldThrowExceptionWhenFuelToRefuelIsZero()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 7.5;
            var fuelCapacity = 50.0;
            var fuelToRefuel = 0;
            //Act
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            //Assert
            Assert.That(() => car.Refuel(fuelToRefuel), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }
        [Test]
        public void RefuelShouldThrowExceptionWhenFuelToRefuelIsNegative()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 7.5;
            var fuelCapacity = 50.0;
            var fuelToRefuel = -10;
            //Act
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            //Assert
            Assert.That(() => car.Refuel(fuelToRefuel), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }
        [Test]
        public void RefuelShouldIncreaseFuelAmountWhenFuelToRefuelIsPositive()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 7.5;
            var fuelCapacity = 50.0;
            var fuelToRefuel = 10;
            //Act
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            //Assert
            Assert.AreEqual(fuelToRefuel, car.FuelAmount);
        }
        [Test]
        public void RefuelShouldIncreaseFuelAmountWhenFuelToRefuelIsPositiveAndFuelAmountIsNotZero()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 7.5;
            var fuelCapacity = 50.0;
            var fuelToRefuel = 10;
            var fuelToRefuel2 = 20;
            //Act
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            car.Refuel(fuelToRefuel2);
            //Assert
            Assert.AreEqual(fuelToRefuel + fuelToRefuel2, car.FuelAmount);
        }
        [Test]
        public void RefuelShouldIncreaseFuelAmountWhenFuelToRefuelIsPositiveAndFuelAmountIsNotZeroAndFuelAmountIsBiggerThanFuelCapacity()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 7.5;
            var fuelCapacity = 50;
            var fuelToRefuel = 10;
            var fuelToRefuel2 = 60;
            //Act
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            car.Refuel(fuelToRefuel2);
            //Assert
            Assert.AreEqual(fuelCapacity, car.FuelAmount);
        }


    }
}