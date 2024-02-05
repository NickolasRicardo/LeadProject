import { Place, Work } from '@mui/icons-material'
import { Avatar, Button, Grid } from '@mui/material'

type InvitedCardsProps = {
  name: string
  createdAt: Date
  suburb: string
  category: number
  id: number
  description: string
  price: number
}

export function InvitedCard({
  category,
  createdAt,
  description,
  id,
  name,
  suburb,
  price,
}: InvitedCardsProps) {
  function stringToColor(string: string) {
    let hash = 0
    let i

    /* eslint-disable no-bitwise */
    for (i = 0; i < string.length; i += 1) {
      hash = string.charCodeAt(i) + ((hash << 5) - hash)
    }

    let color = '#'

    for (i = 0; i < 3; i += 1) {
      const value = (hash >> (i * 8)) & 0xff
      color += `00${value.toString(16)}`.slice(-2)
    }
    /* eslint-enable no-bitwise */

    return color
  }

  function stringAvatar(name: string) {
    return {
      sx: {
        bgcolor: stringToColor(name),
      },
      children: `${name.split(' ')[0][0]}${name.split(' ')[1][0]}`,
    }
  }

  return (
    <Grid
      container
      style={{
        border: '1px solid black',
        height: 300,
        background: 'white',
      }}
    >
      <Grid
        item
        xs={12}
        style={{
          maxHeight: '15%',
          marginTop: '10px',
          marginBottom: '10px',
          paddingBottom: '10px',
        }}
      >
        <Grid
          container
          style={{
            paddingBottom: '5px',
            borderBottom: '1px solid black',
          }}
        >
          <Grid
            item
            xs={2}
            style={{
              alignContent: 'center',
              display: 'flex',
              justifyContent: 'center',
              alignSelf: 'center',
            }}
          >
            <Avatar {...stringAvatar(name)} />
          </Grid>
          <Grid item xs={10}>
            <Grid container>
              <Grid item xs={12}>
                {name}
              </Grid>
              <Grid item xs={12}>
                {createdAt.toUTCString()}
              </Grid>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
      <Grid item xs={12} style={{ borderBottom: '1px solid black' }}>
        <Grid
          container
          style={{
            marginTop: '10px',
            marginBottom: '10px',
          }}
        >
          <Grid
            item
            xs={4}
            style={{
              maxHeight: '10%',
              display: 'flex',
              alignItems: 'center',
            }}
          >
            <Place />
            {suburb}
          </Grid>
          <Grid
            item
            xs={4}
            style={{
              maxHeight: '10%',
              display: 'flex',
              alignItems: 'center',
            }}
          >
            <Work /> {category}
          </Grid>
          <Grid
            item
            xs={4}
            style={{
              maxHeight: '10%',
              display: 'flex',
              alignItems: 'center',
            }}
          >
            Job ID: {id}
          </Grid>
        </Grid>
      </Grid>
      <Grid
        item
        xs={12}
        style={{ minHeight: '50%', borderBottom: '1px solid black' }}
      >
        <p style={{ padding: '10px' }}>{description}</p>
      </Grid>
      <Grid item xs={12} style={{ height: '15%' }}>
        <Grid container style={{ display: 'flex' }}>
          <Grid item xs={1} style={{ maxHeight: '10%' }} />
          <Grid item xs={2} style={{ maxHeight: '10%' }}>
            <Button variant="contained" color="primary" fullWidth>
              Accept
            </Button>
          </Grid>
          <Grid item xs={1} style={{ maxHeight: '10%' }} />
          <Grid item xs={2} style={{ maxHeight: '10%' }}>
            <Button
              variant="contained"
              color="inherit"
              title="teste"
              fullWidth
              style={{ color: 'black' }}
            >
              Decline
            </Button>
          </Grid>
          <Grid
            item
            xs={4}
            style={{
              maxHeight: '10%',
              alignSelf: 'center',
              textAlign: 'center',
            }}
          >
            ${price} Lead Invitation
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  )
}
