using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InventoryTest
    {
        [Test]
        public void On_Add_Item_Inventory_Will_Have_1_Object() {
            Inventory inventory = new Inventory();
            ItemFactory factory = new ItemFactory();

            inventory.AddItem(factory.CreateArmor());
            Assert.IsTrue(inventory.Items.Count == 1);
        }


        [Test]
        public void Trasnfer_Item_Beetween_Inventories()
        {
            Inventory inventory1 = new Inventory();
            Inventory inventory2 = new Inventory();
            ItemFactory factory = new ItemFactory();

            Item newItem = factory.CreateArmor();
            inventory1.AddItem(newItem);

            inventory1.TransferItem(newItem, inventory2);

            
            Assert.IsTrue(inventory2.Items.Count == 1);
            Assert.IsTrue(inventory1.Items.Count == 0);
        }


        [Test]
        public void Can_Not_SpendMoney_iF_balance_smaller_than_price()
        {
            Inventory inventory = new Inventory();
            inventory.Balance = 0;
            ItemFactory factory = new ItemFactory();
            Item item = factory.CreateArmor();
            item.price = 10;


            Assert.IsFalse(inventory.canBuy(item.price));
        }
        [Test]
        public void Can_SpendMoney_iF_balance_bigger_than_price()
        {
            Inventory inventory = new Inventory();
            inventory.Balance = 100;
            ItemFactory factory = new ItemFactory();
            Item item = factory.CreateArmor();
            item.price = 10;

            Assert.IsTrue(inventory.canBuy(item.price));
        }


        [Test]
        public void Get_Items_Returns_Only_ItemsOFType() {
            Inventory inventory = new Inventory();
            ItemFactory factory = new ItemFactory();
            for (int i = 0; i < 10; i++) {
                inventory.AddItem(factory.CreateArmor());
            }
            for (int i = 0; i < 15; i++)
            {
                inventory.AddItem(factory.CreatePotion());
            }
            for (int i = 0; i < 17; i++)
            {
                inventory.AddItem(factory.CreateWeapon());
            }

            Assert.IsTrue(inventory.GetItems(ItemsCategory.All).Count == 42);
            Assert.IsTrue(inventory.GetItems(ItemsCategory.Weapon).Count == 17);
            Assert.IsTrue(inventory.GetItems(ItemsCategory.Armor).Count == 10);
            Assert.IsTrue(inventory.GetItems(ItemsCategory.Potion).Count == 15);

        }
    }
}
