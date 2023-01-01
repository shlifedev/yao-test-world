export const createWindow = () =>{}
export const setTexture = () => {}
export interface Point{
  x : number,
  y : number,
}
type Anchor = "TopLeft" | "Top" | "Center"
export interface UICreator{
  createWindow : (position : Point, size : Point, anchor : Anchor) => UIWindow, 
}

export interface UIWindow{
  createElement
}

export interface UIElement{
  addChild
}