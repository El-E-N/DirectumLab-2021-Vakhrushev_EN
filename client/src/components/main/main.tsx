import * as React from 'react';
import MainLabel from '../main__label/main__label';
import './main.css';

interface IProps {
  mainTitle: string;
  className?: string;
  values: string[][];
}

const Main: React.FunctionComponent<IProps> = (props) => {
  const className = `main__content ${props.className || ''}`;

  return <main className="main">
    <div className={className}>
      <span className="main__tagline">{'Let\'s start!'}</span>
      <h2 className="main__title">{props.mainTitle}</h2>
      {props.values.map((array, index) => {
        return <MainLabel key={index} title={array[0]} placeholder={array[1]} />;
      })}
      <button className="main__button">Enter</button>
    </div>
  </main>;
};

export default Main;
