import * as React from 'react';

interface IButton {
  className?: string;
  value: any;
  onClick?(): void;
}

const Button: React.FunctionComponent<IButton> = (props) => {
  return <button className={props.className || ''} onClick={props.onClick}>{props.value}</button>;
};

export default Button;
