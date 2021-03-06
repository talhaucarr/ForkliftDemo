using System;
using UnityEditor;
using UnityEngine;

namespace Haste {

  public static class HasteScoring {

    public static float Score(HasteItem item, string queryLower, int queryLen) {
      float score = 0.0f;


      // Force menu item matches to the bottom if path is a folder
      if (AssetDatabase.IsValidFolder(item.path)) {
          score -= 30;              
      }

      if (item.source == HasteHierarchySource.NAME)
      {
          score -= 15;
      }

            var userScore = 1.0f;
      #if !IS_HASTE_PRO
        userScore += item.userScore / 10.0f;
      #endif

      var boundaryMatchCount = HasteStringUtils.LongestCommonSubsequenceLength(queryLower, item.boundariesLower);
      var boundaryQueryRatio = boundaryMatchCount / (float)queryLen;
      var boundaryLen = item.boundariesLower.Length;
      var boundaryUtilization = boundaryLen > 0 ? boundaryMatchCount / (float)boundaryLen : 0.0f;

      score += 40.0f * boundaryQueryRatio;
      score += 40.0f * boundaryUtilization;

      // Favor exact name matches
      if (item.nameLower == queryLower) {
        score += 60.0f;
        return score * userScore;
      }

      // Favor exact path matches
      if (item.pathLower == queryLower) {
        score += 50.0f;
        return score * userScore;
      }

      // Favor prefix name matches
      if (queryLen >= 3 && item.nameLower.IndexOf(queryLower, StringComparison.InvariantCulture) == 0) {
        score += 40.0f;
        return score * userScore;
      }

      // Favor prefix path matches
      if (queryLen >= 3 && item.pathLower.IndexOf(queryLower, StringComparison.InvariantCulture) == 0) {
        score += 30.0f;
        return score * userScore;
      }
     try
     {
        // Favor first char name matches
        if (item.nameLower[0] == queryLower[0])
        {
            score += 20.0f;
            return score * userScore;
        }
     }
     catch { }

      // Favor first char path matches
      if (item.pathLower[0] == queryLower[0]) {
        score += 10.0f;
        return score * userScore;
      }

      return score * userScore;
    }
  }
}
