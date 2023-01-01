function questInit(setting){ 
  setting.setQuestType('collect');
  setting.setRequirement([
    {
      type : 'item',
      id : 1001,
      count : 4,
    }
  ]);
}

function enter(q) {
  q.cameraFocus();
  q.pushNext({
    type: "talk",
    teller: "player",
    script: "안녕? 내 이름은 미야옹이야! 사과 먹을래?",
    meta: null,
  });
  return q;
}

function exit(q) {
  return q;
} 
 
