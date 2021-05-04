import * as React from 'react';
import Card from '../card/card';
import {IRoom} from '../../store/types';
import './deck.css';
import {vote} from '../../store/room/room-action-creators';

interface IProps {
  room: IRoom;
  // eslint-disable-next-line no-unused-vars
  vote(roomId: string, value: string): void;
}

const DeckView: React.FunctionComponent<IProps> = (props) => {
  const handleCardChange = (value: string) => {
    vote(props.room.id, value);
  };

  return <div className="deck">
    {props.room.cards.map((card) => {
      return (
        <Card
          key={card}
          value={card}
          onClick={handleCardChange}
        />
      );
    })}
  </div>;
};

export default DeckView;
