import * as React from 'react';
import Deck from '../deck/deck';
import Menu from '../menu/menu';
import './room.css';

interface ICard {
  value: string;
  isSvg?: boolean;
  d?: string;
}

const deck: Array<ICard> = [
  {value: '0'},
  {value: '0.5'},
  {value: '1'},
  {value: '2'},
  {value: '3'},
  {value: '5'},
  {value: '8'},
  {value: '13'},
  {value: '20'},
  {value: '40'},
  {value: '100'},
  {value: '?'},
  {value: '∞'},
  {value: 'coffee', isSvg: true, d: 'M36.6667 5.5H7.33333V23.8333C7.33333 27.885 10.615 31.1667 14.6667 31.1667H25.6667C29.7183 31.1667 33 27.885 33 23.8333V18.3333H36.6667C38.7017 18.3333 40.3333 16.7017 40.3333 14.6667V9.16667C40.3333 7.13167 38.7017 5.5 36.6667 5.5ZM36.6667 14.6667H33V9.16667H36.6667V14.6667ZM36.6667 38.5H3.66667V34.8333H36.6667V38.5Z'}
];

const Room: React.FunctionComponent = () => {
  return <main className="room">
    <h2 className="room-name">Story</h2>
    <div className="room-content">
      <Deck values={deck}/>
      <Menu/>
    </div>
  </main>;
};

export default Room;
