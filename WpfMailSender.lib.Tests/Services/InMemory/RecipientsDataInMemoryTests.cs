using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfMailSender.lib.Data.LinqToSQL;
using WpfMailSender.lib.Services.InMemory;
using System.Linq;

namespace WpfMailSender.lib.Tests.Services.InMemory
{
    /// <summary>
    /// Сводное описание для RecipientsDataInMemoryTests
    /// </summary>
    [TestClass]
    public class RecipientsDataInMemoryTests
    {
        public RecipientsDataInMemoryTests ()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Add_Method_AddNewItemInService ()
        {

            //Arenge

            const string exp_Descr = "unit test recip";
            const string exp_Email = "unit_test_recip@unit_test_recip.com";

            Recipient new_Recip = new Recipient { Description = exp_Descr, Email = exp_Email };

            RecipientsDataInMemory serv = new RecipientsDataInMemory ();

            //Act

            int tmp_Id = serv.Add ( new_Recip );

            //Assert
            Assert.AreEqual ( new_Recip.Id, tmp_Id );
            Assert.IsTrue ( serv.GetAll ().Contains ( new_Recip ) );

        }

        [TestMethod]
        public void GetById_Method_FindItemInService ()
        {

            //Arenge

            const string exp_Descr = "unit test recip";
            const string exp_Email = "unit_test_recip@unit_test_recip.com";

            Recipient new_Recip = new Recipient { Description = exp_Descr, Email = exp_Email };

            RecipientsDataInMemory serv = new RecipientsDataInMemory ();

            //Act

            int max_Id = serv.GetAll ().Max ( r => r.Id );

            serv.Add ( new_Recip );

            int exp_Id = max_Id + 1;

            //Assert

            Recipient exp_Recip = serv.GetById ( exp_Id );

            Assert.AreEqual ( new_Recip, exp_Recip );
        }

        [TestMethod, ExpectedException ( typeof ( ArgumentOutOfRangeException ) )]
        public void GetById_Method_Throw_ArgumentOutOfRangeExceptionInService_OnNegativeId ()
        {

            //Arenge

            const int exp_Id = -5;

            RecipientsDataInMemory serv = new RecipientsDataInMemory ();

            //Act

            serv.GetById ( exp_Id );


            //Assert


        }
    }
}
