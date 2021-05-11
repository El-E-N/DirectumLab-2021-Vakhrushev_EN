import * as React from 'react';
import Card from '../card/card';
import {IRoom} from '../../store/types';
import './deck.css';

interface IProps {
  room: IRoom | null;
}

const DeckView: React.FunctionComponent<IProps> = (props) => {
  return <div className="deck">
    {props.room && props.room.cards.map((card) => {
      return (
        <Card
          key={card.id}
          card={card}
        />
      );
    })}
  </div>;
};

export default DeckView;
