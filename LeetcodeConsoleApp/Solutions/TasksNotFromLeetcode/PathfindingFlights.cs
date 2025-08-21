namespace LeetcodeConsoleApp.Solutions.TasksNotFromLeetcode
{
    /// <summary>
    /// Task:
    /// We have a list of one-way routes between cities (e.g. "Kyiv -> Paris", "Paris -> NY").
    /// Given a start city and a target city, check if it's possible to travel from start to target
    /// using these routes (directly or with transfers).
    /// 
    /// In other words:
    /// - Cities = nodes
    /// - Routes = directed edges
    /// - Question = Is there a path from start to target?
    /// </summary>

    public class PathfindingFlights : ISolution
    {
        public void Run()
        {
            List<Route> allFlights = [
                new Route("Kyiv","Munich"),
                new Route("Munich","NY"),
                new Route("Munich","Paris"),
                new Route("Paris","London"),
                new Route("Paris","Madrid"),
                new Route("Madrid","Lisbon"),
                new Route("Munich","Kyiv"),
                new Route("Lviv", "Paris")                
                ];

            Route targetRoute = new("Kyiv", "NY");

            (bool result, List<Route> routes) = FindRoutes(targetRoute, allFlights);
            var output = string.Join(Environment.NewLine, routes);
            Console.WriteLine(result ? "List of routes found:" : $"not possible to flight from {targetRoute.From} to {targetRoute.To}");
            Console.WriteLine(output);
        }

        private static (bool result, List<Route> routes) FindRoutes(Route fullRoute, List<Route> allFlights)
        {
            IEnumerable<Route> nextPossibleRoutes = allFlights.Where(x => x.From == fullRoute.From);

            Stack<Route> stack = new(nextPossibleRoutes);
            List<string> visitedCities = [fullRoute.From];
            List<Route> routes = [];


            while (stack.Any())
            {
                Route currentRoute = stack.Pop();

                visitedCities.Add(currentRoute.To);

                routes.Add(currentRoute);

                if (currentRoute.To == fullRoute.To)
                {
                    return (true, routes);
                }

                nextPossibleRoutes = allFlights
                    .Where(x => x.From == currentRoute.To)
                    .Where(route => !visitedCities.Any(x => x == route.To));

                if (!nextPossibleRoutes.Any())
                {
                    routes.Remove(currentRoute);

                    if (!stack.Any(x => x.From == currentRoute.From))
                    {
                        IEnumerable<Route> blindRoutes = routes.Where(x => x.To == currentRoute.From).ToList();
                        foreach (Route route in blindRoutes)
                        {
                            routes.Remove(route);
                        }
                    }

                    continue;
                }

                foreach (var route in nextPossibleRoutes)
                {
                    stack.Push(route);
                }
            }

            return (false, []);
        }
    }

    public record Route(string From, string To);
}
