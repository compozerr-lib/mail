import React from "react"
import { createFileRoute } from '@tanstack/react-router'
import MailComponent from '../../mail-component'

export const Route = createFileRoute('/mail/')({
  component: RouteComponent,
})

function RouteComponent() {
  return (
    <div>
      <MailComponent name="World!" />
    </div>
  )
}
