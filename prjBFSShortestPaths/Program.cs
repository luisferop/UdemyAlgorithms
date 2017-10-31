﻿using System;

namespace prjBFSShortestPaths
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedGraph g = new DirectedGraph();

            g.InserVertex("zero");
            g.InserVertex("one");
            g.InserVertex("two");
            g.InserVertex("three");
            g.InserVertex("four");
            g.InserVertex("five");
            g.InserVertex("six");
            g.InserVertex("seven");
            g.InserVertex("eight");
            g.InserVertex("nine");
            g.InserVertex("zero");

            g.InsertEdge("zero", "one");
            g.InsertEdge("zero", "three");
            g.InsertEdge("one", "two");
            g.InsertEdge("one", "four");
            g.InsertEdge("one", "five");
            g.InsertEdge("two", "three");
            g.InsertEdge("two", "five");
            g.InsertEdge("three", "six");
            g.InsertEdge("four", "five");
            g.InsertEdge("four", "seven");
            g.InsertEdge("five", "six");
            g.InsertEdge("five", "eight");
            g.InsertEdge("six", "eight");
            g.InsertEdge("six", "nine");
            g.InsertEdge("seven", "eight");
            g.InsertEdge("eight", "nine");

            g.FindShortestPath("two");
            Console.ReadLine();
        }
    }
}
