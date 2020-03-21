using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDo.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInit()
        {
            var todo = new ToDoList.Models.ToDo();
            todo.Id = 10;
            todo.Text = "test item";
            todo.DueDate = new DateTime(2020, 3, 21);
            todo.Completed = false;
            todo.CreatedAt = new DateTime(2020, 3, 20);

            Assert.AreEqual(10, todo.Id);
            Assert.AreEqual("test item", todo.Text);
            Assert.AreEqual(new DateTime(2020, 3, 21), todo.DueDate);

            // 期日のフォーマットチェック
            Assert.AreEqual(true, todo.UseDueDate);
            Assert.AreEqual(new DateTime(2020, 3, 21), todo.DispDueDate);
            Assert.AreEqual("2020-03-21", todo.StrDueDate);
        }


        [TestMethod]
        public void TestDueDataIsNull()
        {
            var todo = new ToDoList.Models.ToDo();
            todo.Id = 10;
            todo.Text = "test item";
            todo.DueDate = null;
            todo.Completed = false;
            todo.CreatedAt = new DateTime(2020, 3, 20);

            // 期日のフォーマットチェック
            Assert.AreEqual(false, todo.UseDueDate);
            Assert.IsNotNull(todo.DispDueDate);
            Assert.AreEqual("", todo.StrDueDate);
        }
    }
    [TestClass]
    public class ToDoCollectionTest
    {
        /// <sumary>
        /// 簡単なテスト
        /// </sumary>
        [TestMethod]
        public void TestInit()
        {
            var items = new ToDoFiltableCollection();
            Assert.AreEqual(0, items.Count);
            items.Add(new ToDoList.Models.ToDo()
            {
                Id = 1,
                Text = "ccc",
                DueDate = new DateTime(2020, 4, 21),
                CreatedAt = new DateTime(2020, 3, 20)
            });
            Assert.AreEqual(1, items.Count);
            items.Add(new ToDoList.Models.ToDo()
            {
                Id = 2,
                Text = "bbb",
                DueDate = new DateTime(2020, 4, 22),
                CreatedAt = new DateTime(2020, 3, 19)
            });
            Assert.AreEqual(2, items.Count);
            items.Add(new ToDoList.Models.ToDo()
            {
                Id = 3,
                Text = "aaa",
                DueDate = new DateTime(2020, 4, 23),
                CreatedAt = new DateTime(2020, 3, 18)
            });
            Assert.AreEqual(3, items.Count);

            var lst = new List<ToDoList.Models.ToDo>();

            lst.Add(new ToDoList.Models.ToDo()
            {
                Id = 1,
                Text = "ccc",
                DueDate = new DateTime(2020, 4, 21),
                CreatedAt = new DateTime(2020, 3, 20)
            });
            lst.Add(new ToDoList.Models.ToDo()
            {
                Id = 2,
                Text = "bbb",
                DueDate = new DateTime(2020, 4, 22),
                CreatedAt = new DateTime(2020, 3, 19)
            });
            lst.Add(new ToDoList.Models.ToDo()
            {
                Id = 3,
                Text = "aaa",
                DueDate = new DateTime(2020, 4, 23),
                CreatedAt = new DateTime(2020, 3, 18)
            });
            items = new ToDoFiltableCollection(lst);
            Assert.AreEqual(3, items.Count);
        }

        /// <sumary>
        /// 完了フラグでフィルターする
        /// </sumary>
        [TestMethod]
        public void TestFilter()
        {
            var lst = new List<ToDoList.Models.ToDo>();

            Assert.AreEqual(0, lst.Count);
            lst.Add(new ToDoList.Models.ToDo()
            {
                Id = 1,
                Text = "ccc",
                DueDate = new DateTime(2020, 4, 21),
                CreatedAt = new DateTime(2020, 3, 20),
                Completed = false
            });
            Assert.AreEqual(1, lst.Count);
            lst.Add(new ToDoList.Models.ToDo()
            {
                Id = 2,
                Text = "bbb",
                DueDate = new DateTime(2020, 4, 22),
                CreatedAt = new DateTime(2020, 3, 19),
                Completed = true
            });
            Assert.AreEqual(2, lst.Count);
            lst.Add(new ToDoList.Models.ToDo()
            {
                Id = 3,
                Text = "aaa",
                DueDate = new DateTime(2020, 4, 23),
                CreatedAt = new DateTime(2020, 3, 18),
                Completed = false
            });

            var items = new ToDoFiltableCollection(lst);
            Assert.AreEqual(3, items.Count);

            // 完了を表示しない
            items.SetFilter(false, 0);
            Assert.AreEqual(2, items.Count);
            // 完了を表示する
            items.SetFilter(true, 0);
            Assert.AreEqual(3, items.Count);
        }

        /// <sumary>
        /// 作成日でソートする
        /// </sumary>
        [TestMethod]
        public void TestSortByCreareAt()
        {
            var lst = new List<ToDoList.Models.ToDo>();

            Assert.AreEqual(0, lst.Count);
            lst.Add(new ToDoList.Models.ToDo()
            {
                Id = 1,
                Text = "ccc",
                DueDate = new DateTime(2020, 4, 21),
                CreatedAt = new DateTime(2020, 3, 11),
                Completed = false
            });
            Assert.AreEqual(1, lst.Count);
            lst.Add(new ToDoList.Models.ToDo()
            {
                Id = 2,
                Text = "bbb",
                DueDate = new DateTime(2020, 4, 22),
                CreatedAt = new DateTime(2020, 3, 12),
                Completed = true
            });
            Assert.AreEqual(2, lst.Count);
            lst.Add(new ToDoList.Models.ToDo()
            {
                Id = 3,
                Text = "aaa",
                DueDate = new DateTime(2020, 4, 23),
                CreatedAt = new DateTime(2020, 3, 13),
                Completed = false
            });

            var items = new ToDoFiltableCollection(lst);

            // 作成日順にソートする
            items.SetFilter(true, 0);
            Assert.AreEqual(3, items.Count);

            // 新しい順にソートされる
            Assert.AreEqual("aaa", items[0].Text);
            Assert.AreEqual("bbb", items[1].Text);
            Assert.AreEqual("ccc", items[2].Text);

        }
    }
}
