import * as React from 'react';
import Card from '../card/card';
import './deck.css';

interface ICard {
  value: string;
  isSvg?: boolean;
  d?: string;
}

interface IProps {
  values: Array<ICard>;
}

const Deck: React.FunctionComponent<IProps> = (props) => {
  return <div className="deck">
    {props.values.map((v) => {
      return <Card key={v.value} value={v.value} isSvg={v.isSvg} d={v.d}/>;
    })}
  </div>;
};

export default Deck;
