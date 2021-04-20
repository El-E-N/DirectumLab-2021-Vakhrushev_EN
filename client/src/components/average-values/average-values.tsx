import * as React from 'react';
import './average-values.css';

interface IProps {
  players: number;
  avg: number;
}

const AverageValues: React.FunctionComponent<IProps> = (props) => {
  return <div className="average-values">
    <span className="average-values__count-players">{props.players} Players</span>
    <span className="average-values__word-voted">voted</span>
    <span className="average-values__avg">Avg: {props.avg}</span>
  </div>;
};

export default AverageValues;
