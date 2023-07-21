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


        [Test]
        public void DriveShouldDecreaseFuelAmountWhenFuelNeededIsSmallerThanFuelAmount()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 5;
            var fuelCapacity = 50;
            var fuelToRefuel = 10;
            var distance = 100;
            //Act
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            car.Drive(distance);
            //Assert
            Assert.AreEqual(fuelToRefuel - (distance / 100 * fuelConsumption), car.FuelAmount);
              
        }
        //test drive method

        public void DriveShouldDecreaseFuelAmountWhenFuelNeededIsSmallerThanFuelAmountAndFuelAmountIsNotZeroAndFuelAmountIsBiggerThanFuelCapacity()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 5;
            var fuelCapacity = 50;
            var fuelToRefuel = 10;
            var distance = 100;
            var distance2 = 50;
            var distance3 = 100;
            //Act
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            car.Drive(distance);
            car.Drive(distance2);
            car.Drive(distance3);
            //Assert
            Assert.AreEqual(fuelCapacity - (distance / 100 * fuelConsumption) - (distance2 / 100 * fuelConsumption) - (distance3 / 100 * fuelConsumption), car.FuelAmount);
        }
        [Test]
        public void DriveShouldThrowExceptionWhenFuelNeededIsBiggerThanFuelAmount()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 5;
            var fuelCapacity = 50;
            var fuelToRefuel = 10;
            var distance = 100;

            //Act
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);

            //Assert
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance * 3), "You don't have enough fuel to drive!");
        }
        //continue with other tests that are not made already
        [Test]
        public void DriveShouldThrowExceptionWhenFuelNeededIsBiggerThanFuelAmountAndFuelAmountIsNotZeroAndFuelAmountIsBiggerThanFuelCapacity()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 5;
            var fuelCapacity = 50;
            var fuelToRefuel = 10;
            var distance = 100;
            var distance2 = 50;
            var distance3 = 100;
            var distance4 = 100;
            //Act
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            car.Drive(distance);
            car.Drive(distance2);
            car.Drive(distance3);
            //Assert
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance4), "You don't have enough fuel to drive!");

        }
        [Test]
        public void DriveShouldDecreaseFuelAmountWhenFuelNeededIsSmallerThanFuelAmountAndFuelAmountIsNotZeroAndFuelAmountIsBiggerThanFuelCapacityAndRefuelIsCalled()
        {
            //Arrange
            var make = "VW";
            var model = "Golf";
            var fuelConsumption = 5;
            var fuelCapacity = 50;
            var fuelToRefuel = 10;
            var distance = 100;
            var distance2 = 50;
            var distance3 = 100;
            var distance4 = 100;
            var fuelToRefuel2 = 10;
            //Act
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            car.Drive(distance);
            car.Drive(distance2);
            car.Drive(distance3);
            car.Refuel(fuelToRefuel2);
            car.Drive(distance4);
            //Assert
            Assert.AreEqual(fuelCapacity - (distance / 100 * fuelConsumption) - (distance2 / 100 * fuelConsumption) - (distance3 / 100 * fuelConsumption) - (distance4 / 100 * fuelConsumption), car.FuelAmount);
        }
      

    }
}