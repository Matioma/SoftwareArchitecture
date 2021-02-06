using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class FactoryTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void armor_is_created_an_item()
        {
            ItemFactory itemFactory = new ItemFactory();
            Item item = itemFactory.CreateArmor();

            Assert.IsNotNull(item);
        }
        [Test]
        public void armor_name_is_set()
        {
            ItemFactory itemFactory = new ItemFactory();

            Item item = itemFactory.CreateArmor();

            Assert.AreNotEqual(item.Name, "Default Name");
            Assert.AreNotEqual(item.Name, "");
        }
        [Test]
        public void armor_price_is_not_negative()
        {
            ItemFactory itemFactory = new ItemFactory();

            Item item = itemFactory.CreateArmor();

            Assert.IsTrue(item.Price >= 0);            
        }

        [Test]
        public void armor_has_a_description()
        {
            ItemFactory itemFactory = new ItemFactory();

            Item item = itemFactory.CreateArmor();
            Assert.IsTrue(item.description != "");
        }

        [Test]
        public void weapon_name_is_set()
        {
            ItemFactory itemFactory = new ItemFactory();

            Item item = itemFactory.CreateWeapon();

            Assert.AreNotEqual(item.Name, "Default Name");
            Assert.AreNotEqual(item.Name, "");
        }

        [Test]
        public void weapon_price_is_not_negative()
        {
            ItemFactory itemFactory = new ItemFactory();

            Item item = itemFactory.CreateWeapon();

            Assert.IsTrue(item.Price >= 0);
        }

        [Test]
        public void weapon_has_a_description()
        {
            ItemFactory itemFactory = new ItemFactory();

            Item item = itemFactory.CreateArmor();
            Assert.IsTrue(item.description != "");
        }


        [Test]
        public void potion_name_is_set()
        {
            ItemFactory itemFactory = new ItemFactory();

            Item item = itemFactory.CreatePotion();

            Assert.AreNotEqual(item.Name, "Default Name");
            Assert.AreNotEqual(item.Name, "");
        }

        [Test]
        public void potion_price_is_not_negative()
        {
            ItemFactory itemFactory = new ItemFactory();

            Item item = itemFactory.CreatePotion();

            Assert.IsTrue(item.Price >= 0);
        }

        [Test]
        public void potion_has_a_description()
        {
            ItemFactory itemFactory = new ItemFactory();

            Item item = itemFactory.CreatePotion();
            Assert.IsTrue(item.description != "");
        }
    }
}
