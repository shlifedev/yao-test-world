function enter(q) {
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
 
