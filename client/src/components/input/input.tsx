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

class Input extends React.Component<IProps, unknown> {
  render() {
    return <input
      id={this.props.id}
      className={this.props.className}
      type={this.props.type}
      name={this.props.name}
      readOnly={this.props.readOnly}
      defaultValue={this.props.value}
      placeholder={this.props.placeHolder}
      onBlur={this.props.onBlur}
      onClick={this.props.onClick}
    />;
  }
}

export default Input;
