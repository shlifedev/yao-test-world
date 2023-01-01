interface Dialog{ 
  talk : (data : any) => void,
  yesOrNo : () => boolean,  
  cameraFocus : (targetId : number) => void 
}