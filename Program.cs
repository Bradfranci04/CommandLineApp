namespace CommandLineApp
{
    using System;

    namespace RecipeManager
    {
        class Ingredient
        {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
        }

        class Recipe
        {
            private Ingredient[] ingredients;
            private string[] steps;
            private double scaleFactor = 1.0;

            public void GetRecipeDetails()
            {
                Console.Write("Enter the number of ingredients: ");
                int numIngredients = int.Parse(Console.ReadLine());
                ingredients = new Ingredient[numIngredients];

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"Ingredient {i + 1}:");
                    Ingredient ingredient = new Ingredient();
                    Console.Write("Name: ");
                    ingredient.Name = Console.ReadLine();
                    Console.Write("Quantity: ");
                    ingredient.Quantity = double.Parse(Console.ReadLine());
                    Console.Write("Unit: ");
                    ingredient.Unit = Console.ReadLine();
                    ingredients[i] = ingredient;
                }

                Console.Write("Enter the number of steps: ");
                int numSteps = int.Parse(Console.ReadLine());
                steps = new string[numSteps];

                for (int i = 0; i < numSteps; i++)
                {
                    Console.Write($"Step {i + 1}: ");
                    steps[i] = Console.ReadLine();
                }
            }

            public void DisplayRecipe()
            {
                Console.WriteLine("Recipe:");
                foreach (var ingredient in ingredients)
                {
                    Console.WriteLine($"- {ingredient.Quantity * scaleFactor} {ingredient.Unit} of {ingredient.Name}");
                }
                Console.WriteLine();
                for (int i = 0; i < steps.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {steps[i]}");
                }
                Console.WriteLine();
            }

            public void ScaleRecipe(double factor)
            {
                scaleFactor = factor;
            }

            public void ResetScaling()
            {
                scaleFactor = 1.0;
            }

            public void ClearRecipe()
            {
                ingredients = new Ingredient[0];
                steps = new string[0];
                scaleFactor = 1.0;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Recipe recipe = new Recipe();

                while (true)
                {
                    Console.WriteLine("Welcome to the Recipe Manager!");
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("1. Enter a new recipe");
                    Console.WriteLine("2. Display the current recipe");
                    Console.WriteLine("3. Scale the recipe");
                    Console.WriteLine("4. Reset the recipe scaling");
                    Console.WriteLine("5. Clear the recipe");
                    Console.WriteLine("6. Exit");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            recipe.GetRecipeDetails();
                            break;
                        case 2:
                            recipe.DisplayRecipe();
                            break;
                        case 3:
                            Console.Write("Enter the scaling factor (0.5, 2, or 3): ");
                            double factor = double.Parse(Console.ReadLine());
                            recipe.ScaleRecipe(factor);
                            break;
                        case 4:
                            recipe.ResetScaling();
                            Console.WriteLine("Scaling has been reset to 1.0.");
                            break;
                        case 5:
                            recipe.ClearRecipe();
                            Console.WriteLine("Recipe has been cleared.");
                            break;
                        case 6:
                            Console.WriteLine("Exiting the Recipe Manager...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}

