# PolygonEditor
<p align="center">
  <img width="700" alt="PolygonDrawer" src="https://user-images.githubusercontent.com/74315304/200968735-8d1d6d1d-5fe1-417b-b6c8-4782f808ae4f.png">
</p>
  
## Introduction
  This is a project for *Computer Graphics 2022* course on Computer Science course. Starting this project there were defined crutial functionalities that needed to be implemented into the code, they are:
- Adding, editing and deleting a polygon
- For editing:
  - Moving a point
  - Deleting a point
  - Adding a new point on an edge
  - Moving an edge
  - Moving a polygon
- Adding special contraints call 'Relations', they are:
  - Keeping two edges perpendicular
  - Setting a constant length of an edge
  - Setting a minimal and maximal length for an edge 
- Deleting a relation
- Marking edges that have at least 1 relation 
- Implementing two diffrent alghoritms for drawing straight line
  1. Bresenham's line algorithm
  2. Default line drawing alghoritm

---
## Usage
  User may interact with an app using the User Interface placed in a top row of the main window. Each operation on the selected polygon is done with 
the left mouse button, except from moving the entire polygon which is done with the middle mouse button. 
  Perpendicular edges are marked with the same color (1 edge may have few of them). Edges with length relations are marked with red color.

---
## Alghorithm of relations
  When there is a move on the cavnas that nessesitates fixing of relations, selected polygon calls on itself a function *Repair()* that has it's start
point in a vertex that is being edited. The algorithm takes 2 edges which are incident with the start point and moves them in the opposite direction 
until neither of them needs fixing or they meet in an end point.

## Assumptions
* At least one edge in every polygon stays unrelated (in other case the behavior is undefined).
