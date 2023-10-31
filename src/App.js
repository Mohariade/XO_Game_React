import './App.css';
import react, { useState , useEffect} from 'react';


function Box({value, stl, onBoxClick}){
  
  
  return(
    <div className="cell" id={stl} onClick={onBoxClick}>
      <h1>
        {value}
      </h1>
    </div>
  );
}

function Button ({text, onClickButton}){
  return (
    <button onClick={onClickButton}>{text}</button>
  );
}

function SecButton ({children}){
  return (
    <button className="button2">{children}</button>

    
  );
}




function Player({id, stl}){
  return(
    <div className='player' id={stl}>
      Player {id}
    </div>
  );
}

function checkWinner(squares) {
  const lines = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6]
  ];
  for (let i = 0; i < lines.length; i++) {
    let [a, b, c] = lines[i];
    if (squares[a] && squares[a] === squares[b] && squares[a] === squares[c]) {
      return [a, b, c];
    }
  }
  return null;
}

export default function App() {

  const [boxStyles, setBoxStyles]=useState(Array(9).fill("default"));

  const [style1, setStyle1]=useState("");
  const [style2, setStyle2]=useState("current-player");
  

  const [nextPlayer, setNextPlayer]=useState("O");
  const [boxes, setBoxes] = useState(Array(9).fill(null));

  const [status, setStatus]= useState(false);

  function replayGame(){
    setBoxes(Array(9).fill(null));
    setBoxStyles(Array(9).fill(null));
  }
  
  function clickHandler(i){

    
    if (boxes[i] || checkWinner(boxes)){
      return
    }

    const nextBoxes=boxes.slice();
    nextBoxes[i]=nextPlayer;
    setBoxes(nextBoxes);
    console.log(nextBoxes);
    console.log(boxes);

    let winLine=checkWinner(nextBoxes);
    console.log(winLine);

    if (winLine){

      const nextBoxStyles=boxStyles.slice();
      nextBoxStyles[winLine[0]]="win-style";
      nextBoxStyles[winLine[1]]="win-style";
      nextBoxStyles[winLine[2]]="win-style";
    
      setBoxStyles(nextBoxStyles);

      return;
    }
    
    if (nextPlayer==="X"){
      setNextPlayer("O");
      setStyle1("default");
      setStyle2("current-player");

    } else {
      setNextPlayer("X");
      setStyle2("default");
      setStyle1("current-player");
    }

    
    
  }

  return (

    <>
    
    <div className='main-container'>

          <div className='v-container' id='matrix-button'>

            <div id="xo-matrix">
              <div className="v-container">

                <div className="h-container">
                  <Box value={boxes[0]} stl={boxStyles[0]} onBoxClick={() => clickHandler(0)}/>
                  <Box value={boxes[1]} stl={boxStyles[1]} onBoxClick={() => clickHandler(1)}/>
                  <Box value={boxes[2]} stl={boxStyles[2]} onBoxClick={() => clickHandler(2)}/>
                  
                </div>

                <div className="h-container">
                  <Box value={boxes[3]} stl={boxStyles[3]} onBoxClick={() => clickHandler(3)}/>
                  <Box value={boxes[4]} stl={boxStyles[4]} onBoxClick={() => clickHandler(4)}/>
                  <Box value={boxes[5]} stl={boxStyles[5]} onBoxClick={() => clickHandler(5)}/>
                </div>

                <div className="h-container">
                  <Box value={boxes[6]} stl={boxStyles[6]} onBoxClick={() => clickHandler(6)}/>
                  <Box value={boxes[7]} stl={boxStyles[7]} onBoxClick={() => clickHandler(7)}/>
                  <Box value={boxes[8]} stl={boxStyles[8]} onBoxClick={() => clickHandler(8)}/>
                </div>


              </div>

          
            </div>

          <Button text={"Replay"} onClickButton={replayGame}/>

          </div>


        
        <div className="v-container" id='players-result'>
          <div className='h-container'id='players'>

              <Player id={"X"} stl={style1}/>
              <Player id={"O"} stl={style2}/>

          </div>

          <h1 id='result'>{checkWinner(boxes) &&  "Winner!"}</h1>

        </div>


    </div>

        
        
    

    
  </>
  );
}


