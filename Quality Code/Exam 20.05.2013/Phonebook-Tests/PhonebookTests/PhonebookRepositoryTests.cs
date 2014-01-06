using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook;

namespace PhonebookTests
{
    // DISCLAIMER: Some tests could duplicate partially
    // dotCover reports 99% code coverage in IPhonebookRepository class
    [TestClass]
    public class PhonebookRepositoryTests
    {
        // AddPhone TESTS below
        [TestMethod]
        public void AddPhoneTest_Single()
        {
            IPhonebookRepository phonebook = new PhonebookRepository();
            string  name = "Kalina";
            string[] phones = {"+359899777235", "+35929811111"};
            bool isNewEntry = phonebook.AddPhone(name, phones);
            Assert.IsTrue(isNewEntry);
            Assert.IsTrue(phonebook.ListEntries(0, 2) == null); // there is only one entry
            string actual = phonebook.ListEntries(0, 1)[0].ToString();
            Assert.AreEqual("[Kalina: +35929811111, +359899777235]", actual);
        }

        [TestMethod]
        public void AddPhoneTest_Repetitive()
        {
            IPhonebookRepository phonebook = new PhonebookRepository();
            string name = "Kalina";
            string[] phones = { "+359899777235", "+35929811111" };
            phonebook.AddPhone(name, phones);

            string name2 = "KALINA";
            string[] phones2 = { "+359899777236" };
            bool isNewEntry = phonebook.AddPhone(name2, phones2);
            Assert.IsFalse(isNewEntry);
            Assert.IsTrue(phonebook.ListEntries(0, 2) == null); // there is only one entry
            string actual = phonebook.ListEntries(0, 1)[0].ToString();
            Assert.AreEqual("[Kalina: +35929811111, +359899777235, +359899777236]", actual);
        }

        [TestMethod]
        public void AddPhoneTest_TwoEntries()
        {
            IPhonebookRepository phonebook = new PhonebookRepository();
            string name = "Kalina";
            string[] phones = { "+359899777235", "+35929811111" };
            phonebook.AddPhone(name, phones);

            string name2 = "Kalina New";
            string[] phones2 = { "+359899777235", "+35929811111" };
            bool isNewEntry = phonebook.AddPhone(name2, phones2);
            Assert.IsTrue(isNewEntry);
            Assert.IsTrue(phonebook.ListEntries(0, 2).Length == 2); // there is 2 entries
            Assert.IsTrue(phonebook.ListEntries(0, 3) == null); // but not 3
            string actual = phonebook.ListEntries(0, 2)[1].ToString();
            Assert.AreEqual("[Kalina New: +35929811111, +359899777235]", actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void AddPhoneTest_TwoDuplicatedEntries()
        {
            IPhonebookRepository phonebook = new PhonebookRepository();
            string name = "Kalina";
            string[] phones = { "+359899777235", "+35929811111" };
            phonebook.AddPhone(name, phones);

            string name2 = "Kalina New";
            string[] phones2 = { "+359899777235", "+35929811111" };
            phonebook.AddPhone(name2, phones2);
            (phonebook as PhonebookRepository).Entries[0].Name = name2; // duplication
            phonebook.AddPhone(name2, phones2);
        }

        // ChangePhone TESTS below
        [TestMethod]
        public void ChangePhoneTest_ChangeNone()
        {
            IPhonebookRepository phonebook = new PhonebookRepository();
            string name = "Kalina";
            string[] phones = { "+359899777235", "+35929811111" };
            phonebook.AddPhone(name, phones);
            int actuallyChanged = phonebook.ChangePhone("+358", "");
            Assert.AreEqual(0, actuallyChanged);
            string actual = phonebook.ListEntries(0, 1)[0].ToString();
            Assert.AreEqual("[Kalina: +35929811111, +359899777235]", actual); // record is not changed
        }

        [TestMethod]
        public void ChangePhoneTest_ChangeSingle()
        {
            IPhonebookRepository phonebook = new PhonebookRepository();
            string name = "Kalina";
            string[] phones = { "+359899777235", "+35929811111" };
            phonebook.AddPhone(name, phones);
            int actuallyChanged = phonebook.ChangePhone("+35929811111", "+35929811112");
            Assert.AreEqual(1, actuallyChanged);
            string actual = phonebook.ListEntries(0, 1)[0].ToString();
            Assert.AreEqual("[Kalina: +35929811112, +359899777235]", actual); // record is changed
        }

        [TestMethod]
        public void ChangePhoneTest_ChangeMany()
        {
            IPhonebookRepository phonebook = new PhonebookRepository();
            string[] phones = { "+359899777235", "+35929811111" };
            phonebook.AddPhone("Kalina", phones);
            phonebook.AddPhone("Pesho", phones);
            phonebook.AddPhone("Gosho", phones);
            phonebook.AddPhone("Tosho", new string[] { "+359899777236", "+35929811112" }); // different
            int actuallyChanged = phonebook.ChangePhone("+35929811111", "+35929811112");
            Assert.AreEqual(3, actuallyChanged);
            string actual1 = phonebook.ListEntries(0, 4)[0].ToString();
            string actual2 = phonebook.ListEntries(0, 4)[1].ToString();
            string actual3 = phonebook.ListEntries(0, 4)[2].ToString();
            Assert.AreEqual("[Gosho: +35929811112, +359899777235]", actual1); // record is changed
            Assert.AreEqual("[Kalina: +35929811112, +359899777235]", actual2); // record is changed
            Assert.AreEqual("[Pesho: +35929811112, +359899777235]", actual3); // record is changed
        }

        // ListEntries TESTS below
        [TestMethod]
        public void ListEntriesTest_None()
        {
            IPhonebookRepository phonebook = new PhonebookRepository();
            Assert.IsTrue(phonebook.ListEntries(0, 1) == null); // there is no entries initially
        }

        [TestMethod]
        public void ListEntriesTest_Single()
        {
            IPhonebookRepository phonebook = new PhonebookRepository();
            string name = "Kalina";
            string[] phones = { "+359899777235", "+35929811111" };
            phonebook.AddPhone(name, phones);
            Assert.IsTrue(phonebook.ListEntries(0, 2) == null); // there is only one entry
            string actual = phonebook.ListEntries(0, 1)[0].ToString();
            Assert.AreEqual("[Kalina: +35929811111, +359899777235]", actual);
        }


        [TestMethod]
        public void ListEntriesTest_TwoEntries()
        {
            IPhonebookRepository phonebook = new PhonebookRepository();
            string name = "Kalina";
            string[] phones = { "+359899777235", "+35929811111" };
            phonebook.AddPhone(name, phones);

            string name2 = "Kalina New";
            string[] phones2 = { "+359899777235", "+35929811111" };
            phonebook.AddPhone(name2, phones2);
            Assert.IsTrue(phonebook.ListEntries(0, 2).Length == 2); // there is 2 entries
            Assert.IsTrue(phonebook.ListEntries(0, 3) == null); // but not 3
        }
    }
}
