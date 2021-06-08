import * as React from 'react';

interface IProps {
  className?: string;
  type: string;
  name: string;
  value?: string;
  placeHolder?: string;
  readOnly?: boolean;
  id?: string;
  onBlur?(evt: React.ChangeEvent<HTMLInputElement>): void;
  onClick?(): void;
}

const Input: React.FunctionComponent<IProps> = (props) => {
  return <input
    required={true}
    id={props.id}
    className={props.className}
    type={props.type}
    name={props.name}
    readOnly={props.readOnly}
    defaultValue={props.value}
    placeholder={props.placeHolder}
    onBlur={props.onBlur}
    onClick={props.onClick}
  />;
}

export default Input;
