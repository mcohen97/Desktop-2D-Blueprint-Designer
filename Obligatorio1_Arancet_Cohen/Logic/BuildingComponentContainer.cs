﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Logic {
    public class BuildingComponentContainer {

        private ICollection<Wall> wallList;
        private ICollection<Beam> beamList;
        private ICollection<Opening> openingList;

        public BuildingComponentContainer() {
            wallList = new List<Wall>();
            beamList = new List<Beam>();
            openingList = new List<Opening>();
        }

        public bool isWallsEmpty() {
            return wallList.Count == 0;//couln't find anything like isEmpty();
        }

        public bool isBeamsEmpty() {
            return beamList.Count == 0;
        }

        public bool isOpeningsEmpty() {
            return openingList.Count == 0;
        }

        public void addWall(Wall aWall) {
            if (aWall == null) {
                throw new ArgumentNullException();
            }
            wallList.Add(aWall);
            
        }

        public int WallsCount() {
            return wallList.Count;
        }

        public void AddBeam(Beam aBeam) {
            if (aBeam == null) {
                throw new ArgumentNullException();
            }
            beamList.Add(aBeam);
        }

        public int BeamsCount() {
            return beamList.Count;
        }

        public void AddOpening(Opening anOpening) {
            if (anOpening == null) {
                throw new ArgumentNullException();
            }
            openingList.Add(anOpening);
        }

        public int OpeningsCount() {
            return openingList.Count;
        }

        public void RemoveWall(Wall aWall) {
            if (aWall == null) {
                throw new ArgumentNullException();
            }
            wallList.Remove(aWall);
        }

        public void RemoveBeam(Beam aBeam) {
            if (aBeam == null) {
                throw new ArgumentNullException();
            }
            beamList.Remove(aBeam);
        }

        public void RemoveOpening(Opening anOpening) {
            if (anOpening == null) {
                throw new ArgumentNullException();
            }
            openingList.Remove(anOpening);
        }

        public ICollection GetWalls() {
            return (ICollection)wallList;
        }

        public ICollection GetBeams() {
           return (ICollection)beamList;
        }

        public ICollection GetOpenings() {
            return (ICollection)openingList;
        }

        public bool ContainsWall(Wall aWall) {
            if (aWall == null) {
                throw new ArgumentNullException();
            }
            return wallList.Contains(aWall);
        }

        public bool ContainsBeam(Beam aBeam) {
            if (aBeam == null) {
                throw new ArgumentNullException();
            }
            return beamList.Contains(aBeam);
        }

        public bool ContainsOpening(Opening anOpening) {
            if (anOpening == null) {
                throw new ArgumentNullException();
            }
            return openingList.Contains(anOpening);
        }
    }
}