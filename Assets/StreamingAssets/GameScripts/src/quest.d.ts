type QuestType = "Deliver" | "Collect" 
 

interface Quest{
  giver : number,
  talk : (data : QuestTalk) => void,
  yesOrNo : () => boolean,  
  cameraFocus : (targetId : number) => void
}

