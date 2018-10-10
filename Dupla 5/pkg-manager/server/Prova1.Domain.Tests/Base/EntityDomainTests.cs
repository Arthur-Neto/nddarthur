using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.Domain.Tests.Base
{
    [TestFixture]
    public class EntityDomainTests
    {
        /// <summary>
        /// Usamos o EntityFake apenas para expor Entity. 
        /// Como temos controle do Fake, garantimos o comportamento original de Entity
        /// </summary>
        private EntityFake _entity;

        /// <summary>
        /// Usado para comparações.
        /// </summary>
        private EntityFake _anotherEntity;

        [SetUp]
        public void Initialize() {
            _entity = new EntityFake();
            _anotherEntity = new EntityFake();
        }

        #region EQUALS

        [Test]
        public void Entity_Domain_Equals_SameObjects_ShouldBeOk()
        {
            var isEqual = _entity.Equals(_entity);
            isEqual.Should().BeTrue();
        }

        [Test]
        public void Entity_Domain_Equals_SameIds_ShouldBeOk() {
            var id = 10;
            _entity.Id = id;
            _anotherEntity.Id = id;
            var isEqual = _entity.Equals(_anotherEntity);
            isEqual.Should().BeTrue();
        }

        [Test]
        public void Entity_Domain_Equals_DistinctIds_ShouldBeOk()
        {
            _entity.Id = 10;
            _anotherEntity.Id = 20;
            var isEqual = _entity.Equals(_anotherEntity);
            isEqual.Should().BeFalse();
        }

        [Test]
        public void Entity_Domain_Equals_WithNull_ShouldBeOk()
        {
            _entity.Id = 20;
            _anotherEntity = null;
            var isEqual = _entity.Equals(_anotherEntity);
            isEqual.Should().BeFalse();
        }
        [Test]
        public void Entity_Domain_Equals_WithZero_ShouldBeOk()
        {
            _entity.Id = 0;
            _anotherEntity.Id = 20;
            var isEqual = _entity.Equals(_anotherEntity);
            isEqual.Should().BeFalse();
        }

        #endregion

        #region OPERATOR EQUALS
        [Test]
        public void Entity_Domain_OperatorEquals_SameObjects_ShouldBeOk()
        {
            var isEqual = _entity ==_entity;
            isEqual.Should().BeTrue();
        }

        [Test]
        public void Entity_Domain_OperatorEquals_SameIds_ShouldBeOk()
        {
            var id = 10;
            _entity.Id = id;
            _anotherEntity.Id = id;
            var isEqual = _entity ==_anotherEntity;
            isEqual.Should().BeTrue();
        }

        [Test]
        public void Entity_Domain_OperatorEqual_DistinctIds_ShouldBeOk()
        {
            _entity.Id = 10;
            _anotherEntity.Id = 20;
            var isEqual = _entity ==_anotherEntity;
            isEqual.Should().BeFalse();
        }

        [Test]
        public void Entity_Domain_OperatorEqual_WithOnlyNull_ShouldBeOk()
        {
            _entity = null;
            _anotherEntity = null;
            var isEqual = _entity == _anotherEntity;
            isEqual.Should().BeTrue();
        }

        #endregion

        #region HASH CODE 

        [Test]
        public void Entity_Domain_GetHashCode_ShouldBeOk()
        {
            _entity.Id = 10;
            var hash = _entity.GetHashCode();
            hash.Should().Be(_entity.Id.GetHashCode());
        }

        #endregion

        #region VALIDATE

        [Test]
        public void Entity_Domain_Validate_ShouldBeOk()
        {
            var isValid = _entity.Validate();
            isValid.Should().BeTrue();
        }

        #endregion
    }
}
