﻿using System;
using System.Collections.Generic;
using Rareform.Extensions;

namespace Espera.Core
{
    public abstract class SongFinder<T> where T : Song
    {
        private readonly List<T> songsFound;

        protected ICollection<T> InternSongsFound
        {
            get { return this.songsFound; }
        }

        /// <summary>
        /// Occurs when a song has been found.
        /// </summary>
        public event EventHandler<SongEventArgs> SongFound;

        /// <summary>
        /// Occurs when the song crawler has finished.
        /// </summary>
        public event EventHandler Finished;

        /// <summary>
        /// Gets the songs that have been found.
        /// </summary>
        /// <value>The songs that have been found.</value>
        public IEnumerable<T> SongsFound
        {
            get { return this.songsFound; }
        }

        protected SongFinder()
        {
            this.songsFound = new List<T>();
        }

        /// <summary>
        /// Starts the <see cref="SongFinder{T}"/>.
        /// </summary>
        public abstract void Start();

        protected virtual void OnSongFound(SongEventArgs e)
        {
            this.SongFound.RaiseSafe(this, e);
        }

        protected virtual void OnFinished(EventArgs e)
        {
            this.Finished.RaiseSafe(this, e);
        }
    }
}