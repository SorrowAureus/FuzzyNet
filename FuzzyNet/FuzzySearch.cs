﻿
/**
 * FuzzySearch facade class
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FuzzyNet
{
  public class FuzzySearch {


    /**
     * Calculates a Levenshtein simple ratio between the strings.
     * This is indicates a measure of similarity
     *
     * @param s1 Input string
     * @param s2 Input string
     * @return The simple ratio
     */
    public static int Ratio(string s1, string s2) {

      return new SimpleRatio().apply(s1, s2);

    }

    /**
     * Calculates a Levenshtein simple ratio between the strings.
     * This is indicates a measure of similarity
     *
     * @param s1 Input string
     * @param s2 Input string
     * @param stringProcessor Functor which transforms strings before
     *                        calculating the ratio
     * @return The simple ratio
     */
    public static int Ratio(string s1, string s2, StringProcessor stringProcessor) {

      return new SimpleRatio().apply(s1, s2, stringProcessor);

    }

    /**
     * Inconsistent substrings lead to problems in matching. This ratio
     * uses a heuristic called "best partial" for when two strings
     * are of noticeably different lengths.
     *
     * @param s1 Input string
     * @param s2 Input string
     * @return The partial ratio
     */
    public static int PartialRatio(string s1, string s2) {

      return new PartialRatio().apply(s1, s2);

    }

    /**
     * Inconsistent substrings lead to problems in matching. This ratio
     * uses a heuristic called "best partial" for when two strings
     * are of noticeably different lengths.
     *
     * @param s1 Input string
     * @param s2 Input string
     * @param stringProcessor Functor which transforms strings before
     *                        calculating the ratio
     * @return The partial ratio
     */
    public static int PartialRatio(string s1, string s2, StringProcessor stringProcessor) {

      return new PartialRatio().apply(s1, s2, stringProcessor);

    }

    /**
     * Find all alphanumeric tokens in the string and sort
     * those tokens and then take ratio of resulting
     * joined strings.
     *
     * @param s1 Input string
     * @param s2 Input string
     * @return The partial ratio of the strings
     */
    public static int TokenSortPartialRatio(string s1, string s2) {

      return new TokenSort().apply(s1, s2, new PartialRatio());

    }

    /**
     * Find all alphanumeric tokens in the string and sort
     * those tokens and then take ratio of resulting
     * joined strings.
     *
     * @param s1              Input string
     * @param s2              Input string
     * @param stringProcessor Functor which transforms strings before
     *                        calculating the ratio
     * @return The partial ratio of the strings
     */
    public static int TokenSortPartialRatio(string s1, string s2, StringProcessor stringProcessor) {

      return new TokenSort().apply(s1, s2, new PartialRatio(), stringProcessor);

    }

    /**
     * Find all alphanumeric tokens in the string and sort
     * those tokens and then take ratio of resulting
     * joined strings.
     *
     * @param s1 Input string
     * @param s2 Input string
     * @return The full ratio of the strings
     */
    public static int TokenSortRatio(string s1, string s2) {

      return new TokenSort().apply(s1, s2, new SimpleRatio());

    }

    /**
     * Find all alphanumeric tokens in the string and sort
     * those tokens and then take ratio of resulting
     * joined strings.
     *
     * @param s1              Input string
     * @param s2              Input string
     * @param stringProcessor Functor which transforms strings before
     *                        calculating the ratio
     * @return The full ratio of the strings
     */
    public static int TokenSortRatio(string s1, string s2, StringProcessor stringProcessor) {

      return new TokenSort().apply(s1, s2, new SimpleRatio(), stringProcessor);

    }


    /**
     * Splits the strings into tokens and computes intersections and remainders
     * between the tokens of the two strings. A comparison string is then
     * built up and is compared using the simple ratio algorithm.
     * Useful for strings where words appear redundantly.
     *
     * @param s1 Input string
     * @param s2 Input string
     * @return The ratio of similarity
     */
    public static int TokenSetRatio(string s1, string s2) {

      return new TokenSet().apply(s1, s2, new SimpleRatio());

    }

    /**
     * Splits the strings into tokens and computes intersections and remainders
     * between the tokens of the two strings. A comparison string is then
     * built up and is compared using the simple ratio algorithm.
     * Useful for strings where words appear redundantly.
     *
     * @param s1              Input string
     * @param s2              Input string
     * @param stringProcessor Functor which transforms strings before
     *                        calculating the ratio
     * @return The ratio of similarity
     */
    public static int TokenSetRatio(string s1, string s2, StringProcessor stringProcessor) {

      return new TokenSet().apply(s1, s2, new SimpleRatio(), stringProcessor);

    }

    /**
     * Splits the strings into tokens and computes intersections and remainders
     * between the tokens of the two strings. A comparison string is then
     * built up and is compared using the simple ratio algorithm.
     * Useful for strings where words appear redundantly.
     *
     * @param s1 Input string
     * @param s2 Input string
     * @return The ratio of similarity
     */
    public static int TokenSetPartialRatio(string s1, string s2) {

      return new TokenSet().apply(s1, s2, new PartialRatio());

    }

    /**
     * Splits the strings into tokens and computes intersections and remainders
     * between the tokens of the two strings. A comparison string is then
     * built up and is compared using the simple ratio algorithm.
     * Useful for strings where words appear redundantly.
     *
     * @param s1              Input string
     * @param s2              Input string
     * @param stringProcessor Functor which transforms strings before
     *                        calculating the ratio
     * @return The ratio of similarity
     */
    public static int TokenSetPartialRatio(string s1, string s2, StringProcessor stringProcessor) {

      return new TokenSet().apply(s1, s2, new PartialRatio(), stringProcessor);

    }

    /**
     * Calculates a weighted ratio between the different algorithms for best results
     *
     * @param s1 Input string
     * @param s2 Input string
     * @return The ratio of similarity
     */
    public static int WeightedRatio(string s1, string s2) {

      return new WeightedRatio().apply(s1, s2);

    }

    /**
     * Calculates a weighted ratio between the different algorithms for best results
     *
     * @param s1              Input string
     * @param s2              Input string
     * @param stringProcessor Functor which transforms strings before
     *                        calculating the ratio
     * @return The ratio of similarity
     */
    public static int WeightedRatio(string s1, string s2, StringProcessor stringProcessor) {

      return new WeightedRatio().apply(s1, s2, stringProcessor);

    }

    /**
     * Creates a <b>sorted</b> list of {@link ExtractedResult}  which contain the
     * top @param limit most similar choices
     *
     * @param query   The query string
     * @param choices A list of choices
     * @param func    The scoring function
     * @return A list of the results
     */
    public static List<ExtractedResult> ExtractTop(string query, Collection<string> choices,
      Applicable func, int limit, int cutoff) {

      Extractor extractor = new Extractor(cutoff);
      return extractor.extractTop(query, choices, func, limit);

    }

    /**
     * Creates a <b>sorted</b> list of {@link ExtractedResult} which contain the
     * top @param limit most similar choices
     *
     * @param query   The query string
     * @param choices A list of choices
     * @param limit   Limits the number of results and speeds up
     *                the search (k-top heap sort) is used
     * @param cutoff  Rejects any entries with score below this
     * @return A list of the results
     */
    public static List<ExtractedResult> ExtractTop(string query, Collection<string> choices,
      int limit, int cutoff) {

      Extractor extractor = new Extractor(cutoff);
      return extractor.extractTop(query, choices, new WeightedRatio(), limit);

    }

    /**
     * Creates a <b>sorted</b> list of {@link ExtractedResult} which contain the
     * top @param limit most similar choices
     *
     * @param query   The query string
     * @param choices A list of choices
     * @param func    The scoring function
     * @param limit   The number of results to return
     * @return A list of the results
     */
    public static List<ExtractedResult> ExtractTop(string query, Collection<string> choices,
      Applicable func, int limit) {

      Extractor extractor = new Extractor();

      return extractor.extractTop(query, choices, func, limit);

    }

    /**
     * Creates a <b>sorted</b> list of {@link ExtractedResult} which contain the
     * top @param limit most similar choices
     *
     * @param query   The query string
     * @param choices A list of choices
     * @param limit   The number of results to return
     * @return A list of the results
     */
    public static List<ExtractedResult> ExtractTop(string query, Collection<string> choices,
      int limit) {

      Extractor extractor = new Extractor();

      return extractor.extractTop(query, choices, new WeightedRatio(), limit);

    }

    /**
     * Creates a <b>sorted</b> list of {@link ExtractedResult} which contain all the choices
     * with their corresponding score where higher is more similar
     *
     * @param query   The query string
     * @param choices A list of choices
     * @param func    The scoring function
     * @return A list of the results
     */
    public static List<ExtractedResult> ExtractSorted(string query, Collection<string> choices, Applicable func) {

      Extractor extractor = new Extractor();

      return extractor.extractTop(query, choices, func);

    }


    /**
     * Creates a <b>sorted</b> list of {@link ExtractedResult} which contain all the choices
     * with their corresponding score where higher is more similar
     *
     * @param query   The query string
     * @param choices A list of choices
     * @param func    The scoring function
     * @param cutoff  Keep only scores above cutoff
     * @return A list of the results
     */
    public static List<ExtractedResult> ExtractSorted(string query, Collection<string> choices, Applicable func,
      int cutoff) {

      Extractor extractor = new Extractor(cutoff);

      return extractor.extractTop(query, choices, func);

    }

    /**
     * Creates a <b>sorted</b> list of {@link ExtractedResult} which contain all the choices
     * with their corresponding score where higher is more similar
     *
     * @param query   The query string
     * @param choices A list of choices
     * @return A list of the results
     */
    public static List<ExtractedResult> ExtractSorted(string query, Collection<string> choices) {

      Extractor extractor = new Extractor();

      return extractor.extractTop(query, choices, new WeightedRatio());

    }

    /**
     * Creates a <b>sorted</b> list of {@link ExtractedResult} which contain all the choices
     * with their corresponding score where higher is more similar
     *
     * @param query   The query string
     * @param choices A list of choices
     * @param cutoff  Keep only scores above cutoff
     * @return A list of the results
     */
    public static List<ExtractedResult> ExtractSorted(string query, Collection<string> choices,
      int cutoff) {

      Extractor extractor = new Extractor(cutoff);

      return extractor.extractTop(query, choices, new WeightedRatio());

    }

    /**
     * Creates a list of {@link ExtractedResult} which contain all the choices with
     * their corresponding score where higher is more similar
     *
     * @param query   The query string
     * @param choices A list of choices
     * @param func    The scoring function
     * @return A list of the results
     */
    public static List<ExtractedResult> ExtractAll(string query, Collection<string> choices, Applicable func) {

      Extractor extractor = new Extractor();

      return extractor.extractWithoutOrder(query, choices, func);

    }

    /**
     * Creates a list of {@link ExtractedResult} which contain all the choices with
     * their corresponding score where higher is more similar
     *
     * @param query   The query string
     * @param choices A list of choices
     * @param func    The scoring function
     * @param cutoff  Keep only scores above cutoff
     * @return A list of the results
     */
    public static List<ExtractedResult> ExtractAll(string query, Collection<string> choices, Applicable func,
      int cutoff) {

      Extractor extractor = new Extractor(cutoff);

      return extractor.extractWithoutOrder(query, choices, func);

    }

    /**
     * Creates a list of {@link ExtractedResult} which contain all the choices with
     * their corresponding score where higher is more similar
     *
     * @param query   The query string
     * @param choices A list of choices
     * @return A list of the results
     */
    public static List<ExtractedResult> ExtractAll(string query, Collection<string> choices) {

      Extractor extractor = new Extractor();

      return extractor.extractWithoutOrder(query, choices, new WeightedRatio());

    }

    /**
     * Creates a list of {@link ExtractedResult} which contain all the choices with
     * their corresponding score where higher is more similar
     *
     * @param query   The query string
     * @param choices A list of choices
     * @param cutoff  Keep only scores above cutoff
     * @return A list of the results
     */
    public static List<ExtractedResult> ExtractAll(string query, Collection<string> choices, int cutoff) {

      Extractor extractor = new Extractor(cutoff);

      return extractor.extractWithoutOrder(query, choices, new WeightedRatio());

    }

    /**
     * Find the single best match above a score in a list of choices.
     *
     * @param query   A string to match against
     * @param choices A list of choices
     * @param func    Scoring function
     * @return An object containing the best match and it's score
     */
    public static ExtractedResult ExtractOne(string query, Collection<string> choices, Applicable func) {

      Extractor extractor = new Extractor();

      return extractor.extractOne(query, choices, func);

    }

    /**
     * Find the single best match above a score in a list of choices.
     *
     * @param query   A string to match against
     * @param choices A list of choices
     * @return An object containing the best match and it's score
     */
    public static ExtractedResult ExtractOne(string query, Collection<string> choices) {

      Extractor extractor = new Extractor();

      return extractor.extractOne(query, choices, new WeightedRatio());

    }


  }
}