//  BetListData.cs
//
//  Author:
//       Victor L. Senior (VLS) <betselection(&)gmail.com>
//
//  Web: 
//       http://betselection.cc/betsoftware/
//
//  Sources:
//       http://github.com/betselection/
//
//  Copyright (c) 2014 Victor L. Senior
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

/// <summary>
/// Bet list data.
/// </summary>
namespace Bet__List__Viewer
{
    // Directives
    using System;

    /// <summary>
    /// Bet list data class.
    /// </summary>
    public class BetListData
    {
        /// <summary>
        /// The bet.
        /// </summary>
        private string bet;

        /// <summary>
        /// The location.
        /// </summary>
        private string location;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bet__List__Viewer.BetListData"/> class.
        /// </summary>
        /// <param name="name">Passed name.</param>
        /// <param name="location">Passed location.</param>
        public BetListData(string name, string location)
        {
            // Set name
            this.bet = name;

            // Set location
            this.location = location;
        }

        /// <summary>
        /// Gets or sets the bet.
        /// </summary>
        /// <value>The bet.</value>
        public string Bet
        {
            get
            {
                return this.bet;
            }

            set
            {
                this.bet = value;
            }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
            }
        }
    }
}