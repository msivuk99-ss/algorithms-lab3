using System;
using System.Collections.Generic;

namespace Lab06
{
    public class Category
    {
        public string Name { get; set; }
        public int Products { get; set; }
        public List<Category> Children { get; set; }

        public Category(string name, int products, List<Category> children = null)
        {
            Name = name;
            Products = products;
            Children = children ?? new List<Category>();
        }
    }

    internal class Program
    {
        public static int CallCount = 0;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var catalog = new Category("Каталог", 0, new List<Category>
            {
                new Category("Одяг", 0, new List<Category>
                {
                    new Category("Верхній одяг", 0, new List<Category>
                    {
                        new Category("Куртки", 12),
                        new Category("Пальта", 7)
                    }),
                    new Category("Светри", 15)
                }),
                new Category("Взуття", 4, new List<Category>
                {
                    new Category("Кросівки", 23),
                    new Category("Чоботи", 9)
                }),
                new Category("Аксесуари", 0, new List<Category>
                {
                    new Category("Сумки", 18),
                    new Category("Ремені", 5)
                })
            });

            Console.WriteLine("=== Частина 1. Виведення ієрархії (printTree) ===");
            CallCount = 0;
            PrintTree(catalog, 0);
            Console.WriteLine($"Кількість викликів printTree: {CallCount}\n");

            Console.WriteLine("=== Частина 2. Підрахунок товарів (countProducts) ===");
            CallCount = 0;
            int totalProducts = CountProducts(catalog);
            Console.WriteLine($"Загальна кількість товарів у каталозі: {totalProducts}");
            Console.WriteLine($"Кількість викликів countProducts: {CallCount}\n");

            Console.WriteLine("=== Частина 3. Глибина найдовшої гілки (maxDepth) ===");
            CallCount = 0;
            int depth = MaxDepth(catalog);
            Console.WriteLine($"Глибина найдовшої гілки: {depth}");
            Console.WriteLine($"Кількість викликів maxDepth: {CallCount}\n");
        }

        public static void PrintTree(Category node, int level)
        {
            CallCount++;

            if (node == null) return;

            string indent = new string(' ', level * 2);
            Console.WriteLine($"{indent}{node.Name}");

            foreach (var child in node.Children)
            {
                PrintTree(child, level + 1);
            }
        }

        public static int CountProducts(Category node)
        {
            CallCount++;

            if (node == null) return 0;

            int total = node.Products;

            foreach (var child in node.Children)
            {
                total += CountProducts(child);
            }

            return total;
        }

        public static int MaxDepth(Category node)
        {
            CallCount++;

            if (node == null) return 0;

            if (node.Children == null || node.Children.Count == 0)
            {
                return 1;
            }

            int maxChildDepth = 0;

            foreach (var child in node.Children)
            {
                int childDepth = MaxDepth(child);
                if (childDepth > maxChildDepth)
                {
                    maxChildDepth = childDepth;
                }
            }

            return 1 + maxChildDepth;
        }
    }
}