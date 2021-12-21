using System;
using UnityEngine;

/// <summary>
/// Base mail.
/// </summary>
/// 
[Serializable]
public class DataMail : MonoBehaviour, IComparable<DataMail>
{
    public string SentMessage;
    public DateTime DateTime;
    public int Id { get; set; }
    public bool Read;

    /// <summary>
    /// For sorting purposes. Sorts on <see cref="DateTime"/>.
    /// </summary>
    /// <param name="other">The mail to compare this mail to.</param>
    /// <returns>-1 when <paramref name="other"/> is earlier, 0 when it is the same day, 1 when it is later</returns>
    public int CompareTo(DataMail other)
    {
        return other.DateTime.CompareTo(DateTime);
    }
}
