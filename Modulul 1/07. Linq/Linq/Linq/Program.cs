using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Linq
{
    public static class LinqLesson
    {
        public static void Main(string[] args)
        {
             Filtering();
             Ordering();
             Quantifiers();
             Ordering();
             Projection();
             Grouping();
             Generation();
             ElementOperators();
             DataConversion(); 
             Aggregation();
             SetOperations();
             Joins();
            //Query1(); 

            Ex1();
            Ex2();
            Ex3();
            Ex4();
            Ex5();

          /*  Bike b = new Bike { Model = "Whistler 29R", Year = 2019, Weight = 13.5f, HasSuspension = true, ProducerId = "1" };
            User u = new User("Luky", "1234", "Luky@gmail.com");
            Order o = new Order(4500.00f, u, "Strada x", "0727217166");
            
            Console.WriteLine(b.GetBikeCoeficient());
            Console.WriteLine(u.GetUsernameAndEmail());
            Console.WriteLine(o.GetDiscountedPrice(0.20f));*/


        }

        private static void PrintCollection<T>(IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                Console.WriteLine(item);
            }
        }

        public static void Filtering()
        {
            // Where (deffered execution)
            Console.WriteLine("Where");
            var suspensionBikes = _bikes.Where(bike => bike.HasSuspension);
            PrintCollection(suspensionBikes);
            // Skip
            Console.WriteLine("Skip");
            var allButFirstThree = _bikes.Skip(3);
            PrintCollection(allButFirstThree);
            // SkipWhile
            Console.WriteLine("Skip while");
            var result = _bikes.SkipWhile(bike => bike.Year <= 2020);
            PrintCollection(result);

            // Take
            Console.WriteLine("Take");
            var takeResult = _bikes.Take(2);
            PrintCollection(takeResult);


            // TakeWhile
            Console.WriteLine("Take While");
            var takeWhileResult = _bikes.TakeWhile(bike => bike.Year < 2020);
            PrintCollection(takeWhileResult);

            // Chunk
            Console.WriteLine("Chunk");
            var chunkedResult = _bikes.Chunk(3);
            PrintCollection(chunkedResult);

            // OfType
            Console.WriteLine("OfType");
            var fullSuspensionBikes = _bikes.OfType<FullSuspensionBike>();
            PrintCollection(fullSuspensionBikes);
        }

        public static void Ordering()
        {
            // OrderBy, ThenBy
            Console.WriteLine("OrderBy, ThenBy");
            var ordered = _bikes.OrderBy(x => x.Year).ThenBy(x => x.Weight).ThenBy(x => x.Model).ToList();
            PrintCollection(ordered);

            // OrderByDescending, ThenByDescending
            Console.WriteLine("OrderByDescending, ThenByDescending");
            var orderedDescending = _bikes.OrderByDescending(x => x.Weight).ThenByDescending(x => x.Year).ToList();
            PrintCollection(orderedDescending);

            // Reverse
            Console.WriteLine("Reverese");
            var reverseBikes = _bikes.Reverse();
            PrintCollection(reverseBikes);
        }

        public static void Quantifiers()
        {
            // Any
            Console.WriteLine("Any()");
            Console.WriteLine(_bikes.Any(x => x.Year == 2022));

            // All
            Console.WriteLine("All()");
            Console.WriteLine(_bikes.All(x => x.Year == 2022));

            // Contains
            Console.WriteLine("Contains");
            var s1 = new FullSuspensionBike { Model = "Whistler 29RR", Year = 2019, HasSuspension = true, ProducerId = "1", BackSuspension = "RockShox" };
           Console.WriteLine( _bikes.Contains(s1));

            // SequenceEqual
            Console.WriteLine("SequenceEqual");
            var sequence = new List<Bike>
            {
                new Bike { Model = "Whistler 29R", Year = 2019, Weight = 13.5f, HasSuspension = true, ProducerId = "1"},
                new Bike { Model = "Whistler 27R", Year = 2020, Weight = 13.0f, HasSuspension = true, ProducerId = "1"},
                new Bike { Model = "Raven", Year = 2022, Weight = 11.0f, HasSuspension = true, ProducerId = "1"},
                new Bike { Model = "HighLand Peak", Year = 2015, Weight = 12.5f, HasSuspension = true, ProducerId = "1"}
            };
            Console.WriteLine(_bikes.Take(4).SequenceEqual(sequence));
        }

        public static void Projection()
        {
            // Select (anonymus types)
            Console.WriteLine("Select");
            var models = _bikes.Select(x => x.Model);
            PrintCollection(models);

            // SelectMany
            Console.WriteLine("SelectMany");
            var allBikes = _producers.SelectMany(x => x.Models);
            PrintCollection(allBikes);
        }

        public static void Grouping()
        {
            // GroupBy
            var grupedBikes = _bikes.GroupBy(x => x.Year);

            foreach (var year in grupedBikes)
            {
                Console.WriteLine(year.Key);
                foreach (var bike in year)
                {
                    Console.WriteLine(bike);
                }
            }
        }

        public static void Generation()
        {
            // DefaultIfEmpty
            var bikes2 = new List<Bike>();
            var defaultIfEmpty = bikes2.DefaultIfEmpty();
            // Empty
              var empty = Enumerable.Empty<Bike>;

            // Range
            Console.WriteLine("Range");
             var range = Enumerable.Range(1,5).ToList();
            PrintCollection(range);

            // Repeat
            Console.WriteLine("Repeat");
            var repeat = Enumerable.Repeat("Hello world!", 5);
            PrintCollection(repeat);
        }

        public static void ElementOperators()
        {
            // First, FirstOrDefault
            Console.WriteLine("First");
            var first = _bikes.First(x => x.Year == 2015);
            Console.WriteLine(first);

            // Last, LastOrDefault
            Console.WriteLine("Last");
            var last = _bikes.Last(x => x.Year == 2020);
            Console.WriteLine(last);

            // Single, SingleOrDefault

            Console.WriteLine("Single");
            var single = _bikes.Single(x => x.Model == "Whistler 29RR");
            Console.WriteLine(single);

            // ElementAt, ElementAtOrDefault
            Console.WriteLine("ElementAt");
            var elementAt = _bikes.ElementAt(5);
            Console.WriteLine(elementAt);
        }

        public static void DataConversion()
        {
            // Cast (throws InvalidCastException if unable to cast an item in the collection)
            Console.WriteLine("Cast");
            var cast = _bikes.Cast<Bike>();
            PrintCollection(cast);


            // ToDictionary (simply by a key or with element selector)
            Console.WriteLine("ToDictionary");
            var dictionary = _bikes.ToDictionary(x => x.Model + x.Year + " " + x.Weight, x => x.Year);
            foreach (KeyValuePair<string, int> kv in dictionary)
                Console.WriteLine(kv.Key, kv.Value);

            // ToLookup
            Console.WriteLine("ToLookup");
            var lookup = _bikes.ToLookup(x => x.Model);
            foreach (var KeyValurPair in lookup)
            {
                Console.WriteLine(KeyValurPair.Key);
   
                foreach (var item in lookup[KeyValurPair.Key])
                {
                    Console.WriteLine("\t" + item.Model + "\t" + item.Year + "\t" + item.Weight);
                }
            }
        }

        public static void Aggregation()
        {
            // Aggregate
            Console.WriteLine("Aggregate");
            var allNames = _bikes.Aggregate("", (previewsResult, bike) => previewsResult + bike.Model, allNames => allNames);
            Console.WriteLine(allNames);
          // PrintCollection(allNames);
            // Average
            Console.WriteLine("Average");
            var averageWeight = _bikes.Average(x => x.Weight);
            Console.WriteLine(averageWeight);

            // Count, LongCount
            Console.WriteLine("Count");
            var count = _bikes.Distinct().Count();
            Console.WriteLine(count);

            // Max, MaxBy ( MaxBy imi returneaza obiectul care are maximul)
            Console.WriteLine("Max");
            var maxYear = _bikes.Max(x => x.Year);
            Console.WriteLine(maxYear);

            // Min, MinBy
            Console.WriteLine("Min");
            var minYear = _bikes.Min(x => x.Year);
            Console.WriteLine(minYear);

            // Sum
            Console.WriteLine("Sum");
            var totalWeight = _bikes.Sum(x => x.Weight);
            Console.WriteLine(totalWeight);
        }

        public static void SetOperations()
        {
            // Distinct, DistinctBy
            Console.WriteLine("DisntinctBy");
            var distinctModels = _bikes.DistinctBy(x => x.Model);
            PrintCollection(distinctModels);

            var _bikes2 = new List<Bike>
            {
                new Bike { Model = "Whistler 29R", Year = 2019, Weight = 13.5f, HasSuspension = true, ProducerId = "1"},
                new Bike { Model = "Whistler 27R", Year = 2020, Weight = 13.0f, HasSuspension = true, ProducerId = "1"},
                new Bike { Model = "Raven", Year = 2022, Weight = 11.0f, HasSuspension = true, ProducerId = "1"},
                new Bike { Model = "HighLand Peak", Year = 2015, Weight = 12.5f, HasSuspension = true, ProducerId = "1"},
                new Bike { Model = "HighLand Peadsk", Year = 2015, Weight = 12.5f, HasSuspension = true, ProducerId = "1"}
            };

            // Except, ExeceptBy
            Console.WriteLine("ExceptBy");
            var except = _bikes.ExceptBy(_bikes2, x => x).ToList();
            PrintCollection(except);

            // Intersect, IntersectBy

            Console.WriteLine("IntersectBy");
            var intersectBy = _bikes.IntersectBy(_bikes2.Select(x => x.Year), x => x.Year);
            PrintCollection(intersectBy);

            // Union, UnionBy (distinct union)
            Console.WriteLine("Union");
            var union = _bikes.Union(_bikes2);
            PrintCollection(union);

            // Concat (non distinct)
            Console.WriteLine("Concat");
            var concat = _bikes.Concat(_bikes2);
            PrintCollection(concat);
        }

        public static void Joins()
        {
            // Join (aslo with query language)
            //var facultiesByStudent = _students.Join(
            //    _faculties,
            //    student => student.FacultyId,
            //    faculty => faculty.Id,
            //    (student, faculty) => new { student.FirstName, faculty.Name }
            //    );

            Console.WriteLine("Join");
            var producersByBike = from bike in _bikes
                                     join producer in _producers on bike.ProducerId equals producer.Id
                                     select new { bike, producer.Name };

            var producersByBike2 = _bikes.Join(
                                _producers,
                                bike => bike.ProducerId,
                                producer => producer.Id,
                                (bike,producer) => new { bike, producer.Name });

            PrintCollection(producersByBike);

            // GroupJoin
            var bikesByProducers = from producer in _producers
                                    join bike in _bikes on producer.Id equals bike.ProducerId into bikesGroup
                                    select new { producer.Name, bikesGroup };

            foreach (var bikeGroup in bikesByProducers)
            {
                Console.WriteLine(bikeGroup.Name);
                foreach (var bike in bikeGroup.bikesGroup)
                {
                    Console.WriteLine(bike);
                }

            }

            // Zip
            Console.WriteLine("Zip");
            var zip = _bikes.Zip(_producers, (x, y) => x.Model + " - " + y.Name);
            PrintCollection(zip);
        }

        private static readonly IEnumerable<Bike> _bikes = CreateBikesList();
        private static IEnumerable<Bike> CreateBikesList()
        {
            return new List<Bike>
            {
                new Bike { Model = "Whistler 29R", Year = 2019, Weight = 13.5f, HasSuspension = true, ProducerId = "1"},
                new Bike { Model = "Whistler 27R", Year = 2020, Weight = 13.0f, HasSuspension = true, ProducerId = "1"},
                new Bike { Model = "Raven", Year = 2022, Weight = 11.0f, HasSuspension = true, ProducerId = "1"},
                new Bike { Model = "HighLand Peak", Year = 2015, Weight = 12.5f, HasSuspension = true, ProducerId = "1"},

                new Bike { Model = "Access 27.5R", Year = 2021, Weight = 13.8f, HasSuspension = true, ProducerId = "2"},
                new Bike { Model = "AIM SL 29R", Year = 2019, Weight = 14.2f, HasSuspension = true, ProducerId = "2"},
                new Bike { Model = "AIM SL 29R", Year = 2019, Weight = 15.0f, HasSuspension = true, ProducerId = "2"},
                new Bike { Model = "AIM 29R", Year = 2019, Weight = 14.8f, HasSuspension = true, ProducerId = "2"},

                new Bike { Model = "Scale 970", Year = 2020, Weight = 14.5f, HasSuspension = true, ProducerId = "3"},
                new Bike { Model = "Scale 990", Year = 2021, Weight = 14.0f, HasSuspension = true, ProducerId = "3"},
                new Bike { Model = "Scale 960", Year = 2021, Weight = 13.8f, HasSuspension = true, ProducerId = "3"},

                new Bike { Model = "Nirvana Tour", Year = 2022, Weight = 12.0f, HasSuspension = true, ProducerId = "4"},
                new Bike { Model = "Kato", Year = 2022, Weight = 13.0f, HasSuspension = true, ProducerId = "4"},
                new Bike { Model = "Lanao", Year = 2019, Weight = 12.5f, HasSuspension = false, ProducerId = "4"},
                new FullSuspensionBike { Model = "Whistler 29RR", Year = 2019, HasSuspension = true, ProducerId = "1", BackSuspension = "RockShox"}
              
            };
        }

        private static readonly IEnumerable<Producer> _producers = CreateProducersList();
        private static IEnumerable<Producer> CreateProducersList()
        {
            return new List<Producer>
            {
                new Producer { Name = "FOCUS", Id = "1", Models = new List<Bike>{ new Bike() { Model = "1" }, new Bike() { Model = "2" } } },
                new Producer { Name = "CUBE", Id = "2", Models = new List<Bike>{ new Bike() { Model = "3" }, new Bike() { Model = "4" } } },
                new Producer { Name = "SCOTT", Id = "3", Models = new List<Bike>{ new Bike() { Model = "5" }, new Bike() { Model = "6" } } },
                new Producer { Name = "GHOST", Id = "4" ,  Models = new List<Bike>{ new Bike() { Model = "7" }, new Bike() { Model = "8" } } }

            };
        }

        public static void Query1()
        {
            Console.WriteLine("Query 1");
            var result = _bikes.Join(
                               _producers,
                               bike => bike.ProducerId,
                               producer => producer.Id,
                               (bike,producer) => new {bike.Year, bike.Weight, bike.HasSuspension,producer.Name})
                          .Where(x => x.Year == 2019 && !x.HasSuspension && x.Weight <=14)
                          .Count();
            Console.WriteLine(result);
              

        }

        /// Exercices
        
        public static void Ex1()
        {
            Console.WriteLine("Ex1");
            var array = new int[] { 8, 2, 3, 3, 5, 6, 5, 8, 9, 10, 1, 12, 2, 2, 25, 8, 16, 2 };
            var result = array.GroupBy(x => x)
                .ToDictionary(x => x.Key, y => y.Count());
            foreach(KeyValuePair<int, int> pair in result)
            {
                Console.WriteLine("numar "+ pair.Key +" , repetitii: "+pair.Value);
            }
        }
        public static void Ex2()
        {
            Console.WriteLine("\nEx2");
            var array = new int[] { 8, 2, 3, 3, 5, 6, 5, 8, 9, 10, 1, 12, 2, 2, 25, 8, 16, 2 };
            var result = array.GroupBy(x => x)
                .ToDictionary( x=> x.Key, y => y.Count())
                .Aggregate((a,b) => a.Value>b.Value? a :b);
            Console.WriteLine("Numarul care se repeta de cele mai multe ori este "+ result.Key);
        }
        public static void Ex3()
        {
            Console.WriteLine("\nEx3");
            string[] first = new string[] { "hello", "hi", "max", "good evening", "good day", "good morning", "goodbye" };
            string[] second = new string[] { "whatsup", "how are you", "hello", "bye", "maybe", "hi" };

            var result = first.Intersect(second)
                .Where(x => x.StartsWith("h"));
            PrintCollection(result);
        }
        public static void Ex4()
        {
            Console.WriteLine("\nEx4");
            string[] first = new string[] { "hello", "hi", "max", "good evening", "good day", "good morning", "goodbye" };
            string[] second = new string[] { "whatsup", "how are you", "hello", "bye", "maybe", "hi" };

            var result = first.Aggregate("", (prev, s) => prev + s.Last(), result => result);
            Console.WriteLine(result);

        }

        public static void Ex5()
        {
            Console.WriteLine("\nEx5");
            var result = _producers.Join(
                        _bikes,
                        producer => producer.Id,
                        bike => bike.ProducerId,
                        (producer, bike) => new
                        {
                            Name = producer.Name,
                            Weight = bike.Weight
                        }
                    )
                .GroupBy(x => x.Name)
                .ToDictionary(x => x.Key, y => y.Sum(z => z.Weight))
                .OrderBy(x => x.Value);
            foreach(KeyValuePair<string,double> pair in result)
            {
                Console.WriteLine(pair.Key +" "+ pair.Value.ToString("n2"));
            }
        }
    }
}