using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Collections.Tests
{
    /// <summary>
    /// Class Note.
    /// </summary>
    public class Note : IComparer<Note>, IEquatable<Note>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class.
        /// </summary>
        /// <param name="author">Author of note.</param>
        /// <param name="title">Title of note.</param>
        /// <param name="text">Text.</param>
        /// <param name="id">Id.</param>
        public Note(string author, string title, string text, int id)
        {
            this.Author = author;
            this.Title = title;
            this.Text = text;
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets property.
        /// </summary>
        /// <value>
        /// Author.
        /// </value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets property.
        /// </summary>
        /// <value>
        /// Title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets property.
        /// </summary>
        /// <value>
        /// Text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets property.
        /// </summary>
        /// <value>
        /// Id.
        /// </value>
        public int Id { get; set; }


        /// <summary>
        /// Compares the two objects.
        /// </summary>
        /// <param name="x">first Note.</param>
        /// <param name="y">second Note.</param>
        /// <returns>an integer that indicates their relative position in sort order.</returns>
        public int Compare(Note x, Note y)
        {
            if (x is null || y is null)
            {
                throw new NullReferenceException();
            }

            return string.Compare(x.Title, y.Title, StringComparison.Ordinal);
        }

        /// <summary>
        /// Method Equals.
        /// </summary>
        /// <param name="other">Note to equals.</param>
        /// <returns>true if two objects are equal and false otherwise.</returns>
        public bool Equals(Note other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Author == other.Author && this.Title == other.Title && this.Text == other.Text;
        }

        /// <summary>
        /// GetHashCode method.
        /// </summary>
        /// <returns>Int number.</returns>
        public override int GetHashCode()
        {
            return this.Title.Length.GetHashCode();
        }

        /// <summary>
        /// ToString method.
        /// </summary>
        /// <returns>string representation of an object.</returns>
        public override string ToString() =>
            $"#{this.Id}, {this.Title} was written by {this.Author} . Add has next text {this.Text}";

        /// <summary>
        /// Method Equals.
        /// </summary>
        /// <param name="obj">Object to equals.</param>
        /// <returns>true if two objects are equal and false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Note note = obj as Note;

            return this.Equals(note);
        }
    }
}
