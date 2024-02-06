import React, { createContext, useCallback, useContext } from 'react'
import Services, { IJob } from './services'

interface JobContextData {
  getValues(status: number): void
}

const JobContext = createContext<JobContextData>({} as JobContextData)

export const JobProvider = () => {
  const [jobs, setJobs] = React.useState<IJob[] | []>([])

  const getValues = useCallback(async (status: number) => {
    const services = new Services()
    const { error, response } = await services.GetByStatus(status.toString())
    console.log(response)
    if (!error && response) setJobs(response)
  }, [])
}

export function useJob(): JobContextData {
  const context = useContext(JobContext)

  if (!context) {
    throw new Error('useLoading must be used within an LoadingProvider')
  }
  return context
}
