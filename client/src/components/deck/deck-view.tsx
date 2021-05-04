import * as React from 'react';
import Card from '../card/card';
import {IRoom} from '../../store/types';
import './deck.css';

interface IProps {
  room: IRoom;
  // eslint-disable-next-line no-unused-vars
  updateVote(roomId: string, value: string): void;
}

const DeckView: React.FunctionComponent<IProps> = (props) => {
  const handleCardChange = (value: string) => {
    props.updateVote(props.room.id, value);
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
