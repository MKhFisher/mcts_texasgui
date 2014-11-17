﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace texasholdem_gui
{
    public static class ExtensionMethods
    {
        public static bool ContainsRoyalFlush(this List<CardGUI> hand)
        {
            // Orders 7 cards in descending order and removes last two 
            // (royal flush must be the 5 highest cards in the game 
            // therefore we don't care about the extra 2 cards).
            hand = hand.Where(x => x != null).OrderByDescending(x => x.number).ToList();
            hand.RemoveAt(hand.Count - 1);
            hand.RemoveAt(hand.Count - 1);

            if (hand[0].number != Number.Ace)
            {
                return false;
            }

            // Checks to see if remaining 5 cards is a straight.
            return ContainsStraight(hand) && ContainsFlush(hand);
        }

        public static bool ContainsStraightFlush(this List<CardGUI> hand)
        {
            // Checks for at least a 5 card flush.
            List<CardGUI> flush = hand.Where(x => x != null).GroupBy(x => x.suit).Where(y => y.Count() >= 5).SelectMany(x => x).ToList();
            return ContainsStraight(flush);
        }

        public static bool ContainsFourOfAKind(this List<CardGUI> hand)
        {
            // Looks to see if there exists a group of 4 cards that are the same.
            List<CardGUI> four = hand.Where(x => x != null).GroupBy(x => x.number).Where(y => y.Count() == 4).SelectMany(x => x).ToList();
            return (four.Count == 4);
        }

        public static bool ContainsFullHouse(this List<CardGUI> hand)
        {
            return ContainsThreeOfAKind(hand) && ContainsPair(hand);
        }

        public static bool ContainsFlush(this List<CardGUI> hand)
        {
            // Looks for at least a group of 5 cards of the same suit.
            List<CardGUI> flush = hand.GroupBy(x => x.suit).Where(y => y.Count() >= 5).SelectMany(x => x).ToList();
            return (flush.Count >= 5);
        }

        public static bool ContainsStraight(this List<CardGUI> hand)
        {
            // Looks for at least a 5 card straight.
            List<CardGUI> straight;
            try
            {
                straight = hand.OrderBy(x => x.number)
                    .Select((i, j) => new { i, j })
                    .GroupBy(x => x.i.number - x.j)
                    .Where(y => y.Count() >= 5)
                    .Select(x => x.Select(xx => xx.i))
                    .LastOrDefault()
                    .ToList();
            }
            catch
            {
                //if no straight is found, null exception is thrown because of ToList();
                return false;
            }
            return (straight.Count >= 5);
        }

        public static bool ContainsThreeOfAKind(this List<CardGUI> hand)
        {
            // Looks to see if there are groups of 3 cards the same.
            // Will return true if there are at least one set of 3.
            List<CardGUI> three = hand.Where(x => x != null).GroupBy(x => x.number).Where(y => y.Count() == 3).SelectMany(x => x).ToList();
            return (three.Count >= 3);
        }

        public static bool ContainsTwoPair(this List<CardGUI> hand)
        {
            // Looks to see if there are groups of 2 cards the same.
            List<CardGUI> twopair = hand.Where(x => x != null).GroupBy(x => x.number).Where(y => y.Count() == 2).SelectMany(x => x).ToList();
            return (twopair.Count >= 4);
        }

        public static bool ContainsPair(this List<CardGUI> hand)
        {
            // Looks to see if there are groups of 2 cards the same.
            List<CardGUI> pair = hand.GroupBy(x => x.number).Where(y => y.Count() == 2).SelectMany(x => x).ToList();
            // >= is needed for fullhouse to work properly.
            return (pair.Count >= 2);
        }
    }
}