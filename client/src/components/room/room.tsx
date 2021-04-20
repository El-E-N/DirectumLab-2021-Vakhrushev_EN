import * as React from 'react';
import Deck from '../deck/deck';
import Menu from '../menu/menu';
import {ICard} from '../card/card';
import Results from '../results/results';
import './room.css';

const deck: Array<ICard> = [
  {value: '0', isChecked: false, onChange() {}},
  {value: '0.5', isChecked: false, onChange() {}},
  {value: '1', isChecked: false, onChange() {}},
  {value: '2', isChecked: false, onChange() {}},
  {value: '3', isChecked: false, onChange() {}},
  {value: '5', isChecked: false, onChange() {}},
  {value: '8', isChecked: false, onChange() {}},
  {value: '13', isChecked: false, onChange() {}},
  {value: '20', isChecked: false, onChange() {}},
  {value: '40', isChecked: false, onChange() {}},
  {value: '100', isChecked: false, onChange() {}},
  {value: '?', isChecked: false, onChange() {}},
  {value: '∞', isChecked: false, onChange() {}},
  {value: 'coffee', isSvg: true, isChecked: false, onChange() {}}
];

interface IProps {
  isPlanning?: boolean;
  addEnterStory?: boolean;
}

const Room: React.FunctionComponent<IProps> = (props) => {
  return <main className="room">
    <h2 className="room-name">Story</h2>
    <div className="room-content">
      {props.isPlanning || false ? <Deck values={deck}/> : <Results/>}
      <Menu addEnter={props.addEnterStory}/>
    </div>
  </main>;
};

export default Room;
